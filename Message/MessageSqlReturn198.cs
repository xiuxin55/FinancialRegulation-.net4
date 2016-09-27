using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Message
{
    public class MessageSqlReturn198 : BaseMessageResponse
    {
        public DataSet dsResult { get; set; }

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        } 
    }
}
