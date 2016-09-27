using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
//using System.Data.OracleClient;

namespace Common
{
    public abstract class ObjectPool
    {
        private Int64 _lastCheckOut;

        private  Hashtable loked;
        private  Hashtable unloked;

        internal static Int64 GRABAGE_INTERVAL = 90 * 1000;

        //static ObjectPool()
        //{
        //    loked = Hashtable.Synchronized(new Hashtable());
        //    unloked = Hashtable.Synchronized(new Hashtable());
        //}

        internal ObjectPool()
        {
            loked = Hashtable.Synchronized(new Hashtable());
            unloked = Hashtable.Synchronized(new Hashtable());
            _lastCheckOut = DateTime.Now.Ticks;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = GRABAGE_INTERVAL;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(CollectGarbage);
        }

        protected abstract object Create();

        protected abstract bool Validate(Object o);

        protected abstract void Expire(Object o);

        internal Object GetObjectFromPool()
        {
            long now = DateTime.Now.Ticks;
            _lastCheckOut = now;
            Object o = null;
            lock (this)
            {
                try
                {
                    foreach (DictionaryEntry entry in unloked)
                    {
                        o = entry.Key;
                        if (Validate(o))
                        {
                            unloked.Remove(o);
                            loked.Add(o,now);
                            return o;
                        }
                        else
                        {
                            unloked.Remove(o);
                            Expire(o);
                            o = null;
                        }
                    }
                }
                catch 
                {
                    
                }

                o = Create();
                loked.Add(o, now);
            }

            return o;
        }

        internal void ReturnObjectToPool(Object o)
        {
            if (o != null)
            {
                lock (this)
                {
                    loked.Remove(o);
                    unloked.Add(o,DateTime.Now.Ticks);
                }
            }
        }

        private void CollectGarbage(Object sender, System.Timers.ElapsedEventArgs ea)
        {
            lock (this)
            {
                object o;
                Int64 now = DateTime.Now.Ticks;
                IDictionaryEnumerator e = unloked.GetEnumerator();

                try
                {
                    while (e.MoveNext())
                    {
                        o = e.Key;
                        if (now - ((Int64)unloked[o]) > GRABAGE_INTERVAL)
                        {
                            unloked.Remove(o);
                            Expire(o);
                            o = null;
                        }
                    }
                }
                catch (Exception ) { }
            }
        }
    }

    public sealed class DBConnectionPool : ObjectPool
    {
        private DBConnectionPool() { }

        private DBConnectionPool(string connectionString) 
        {
            this._connectionString = connectionString;
        }

        public static DBConnectionPool GetDBConnectionPool(string connectionString)
        {
            return new DBConnectionPool(connectionString);
        }

        public static readonly DBConnectionPool Instance = new DBConnectionPool();

        private  string _connectionString = "";

        public  string ConnectionString
        {
            set
            {
                _connectionString = value;
            }
            get
            {
                return _connectionString;
            }
        }

        protected override object Create()
        {
            SqlConnection t = new SqlConnection(_connectionString);
            t.Open();
            return t;
        }

        protected override bool Validate(object o)
        {
            try
            {
                SqlConnection t = o as SqlConnection;
                return t.State.Equals(System.Data.ConnectionState.Open);
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        protected override void Expire(object o)
        {
            try
            {
                ((SqlConnection)o).Close();
            }
            catch
            {
            }
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                return base.GetObjectFromPool() as SqlConnection;
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        public void ReturnDBConnection(SqlConnection o)
        {
            base.ReturnObjectToPool(o);
        }
    }
}
