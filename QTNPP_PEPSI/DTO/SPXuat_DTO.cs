using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SPXuat_DTO
    {
        public string MASP { get; set; }
        public string TENSANPHAM { get; set; }
        public string DVT { get; set; }
        public double DONGIA { get; set; }
        public int SOLUONG { get; set; }

        public double THANHTIEN
        {
            get { return SOLUONG * DONGIA; }
        }
    }
}
