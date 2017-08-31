﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lithnet.Miiserver.AutoSync
{
    [CollectionDataContract(Name = "management-agents", ItemName = "management-agent")]
    public class MAConfigParametersCollection : KeyedCollection<string, MAConfigParameters>
    {
        public MAConfigParametersCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public MAConfigParameters GetItemOrDefault(string name)
        {
            if (this.Contains(name))
            {
                return this[name];
            }
            else
            {
                return null;
            }
        }

        public MAConfigParameters GetItemOrDefault(Guid maid)
        {
            return this.FirstOrDefault(t => t.ManagementAgentID == maid);
        }

        protected override string GetKeyForItem(MAConfigParameters item)
        {
            return item.ManagementAgentName;
        }
    }
}
