using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueryLibrary.Models
{
    public class PartModel
    {   //Part_Key, Part_No, Name, Part_Type, Part_Group_Key, Part_group, Building_Key, Unit_Type
        public string PartKey { get; set; }
        public string PartNo { get; set; }
        public string Name { get; set; }
        public string PartType { get; set; }
    }
}
