using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{

    public enum TypeApp
    {
        nguoidung,
        nhanvien
    }

    public class Token
    {
        public string AppToken { get; set; }
        public CodeHeThong CodeHeThong { get; set; }
        public TypeApp? TypeApp { get; set; }

    }
    public class App:BaseModel
    {
        public List<Token> AppTokens { get; set; } 
        public string IdNguoiDung { get; set; }
        public App()
        {
            AppTokens = new List<Token>();
        }
        
    }
}
