using System;
using System.Collections.Generic;
using System.Text;

namespace swag.Core.EF
{
    public class SqlSetting
    {
        public string ConnectionString { get; set; }
        public bool InMemory { get; set; }
    }
}
