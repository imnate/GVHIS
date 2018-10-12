using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadQRcode
{
    public class Table_Row
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string CarNumP { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public byte[] Photo { get; set; }
    }
}
