using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class Vigenere
    {
        public static string nguon = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // khởi tạo mảng thứ tự các ký tự chữ
        public static char[] P = nguon.ToCharArray();// chuyển các ký tự của nguon thành kiểu char
        public static int[] taokhoa(string vao, int[] key) // tạo khóa có chiều dài bằng chiều dài văn bản
        {
            // vao: văn bản cần được mã hóa
            // key là danh sách chỉ số ký tự của khóa. VD k = DAI ==> key = [4, 0, 8]
            char[] vanban = vao.ToCharArray();// chuyển các ký tự của vanban thành kiểu char
            int l = vanban.Length; // trả về chiều dài của chuỗi vanban
            int[] plant = new int[l]; // tạo 1 danh sách đối tượng kiểu int với kích thước là chiều dài chuỗi vanban
            int j = 0; // khởi tạo biến j
            for (int i = 0; i < l; i++) // đưa vào vòng lặp duyệt từ đầu đến cuối vabam
            {
                if (j > key.Length - 1) // nếu j vượt quá chiều dài của key
                    j = 0; // thì gán trở lại bằng 0
                plant[i] = key[j]; // gán chỉ số của key vào plant
                j++; // tăng j để duyệt lại key //> plant = [4,0,8,4,0,8,4,...]
            }
            return plant; // trả về key với chiều dài bằng với vao
        }
        public static int[] chuyenmakey(string s) //Tìm vị trí thứ tự của chữ cái
        {
            char[] vanban = s.ToCharArray();// chuyển các ký tự của s thành kiểu char
            int l = vanban.Length; // trả về chiều dài của chuỗi vanban
            int[] tmp_local = new int[l]; // tạo 1 danh sách đối tượng kiểu int với kích thước là chiều dài chuỗi vanban
            int j = 0; // khởi tạo biến j
            while (j < l) // đưa vào vòng lặp duyệt các phần tử của văn bản
            {
                for (int i = 0; i < P.Length; i++) // đưa vào vòng lặp duyệt từ A -> Z
                {
                    if (P[i] == vanban[j]) // nếu ký tự được duyệt của vanban giống với ký tự được duyệt của P
                        tmp_local[j] = i; // gán chỉ số đó vào biến 
                }
                j++; //tăng j để duyệt lại key
            }
            return tmp_local; // trả về danh sách các ký tự của key (sau này làm giá trị bỏ vào int[] key cho hàm trên)
        }
        public static string Mahoa(string s, int[] khoa) // hàm mã hóa văn bản
        {
            char[] vanban = s.ToCharArray();// chuyển các ký tự của s thành kiểu char
            int l = vanban.Length; // trả về chiều dài của chuỗi vanban
            int[] tmp_local = new int[l]; // tạo 1 danh sách đối tượng kiểu int với kích thước là chiều dài chuỗi vanban
            char[] temp = new char[l]; // tạo 1 danh sách đối tượng kiểu char với kích thước là chiều dài chuỗi vanban
            int maso; // khởi tạo biến maso
            for (int j = 0; j < l; j++) // đưa vào vòng lặp duyệt các phần tử của văn bản
            {
                for (int i = 0; i < P.Length; i++) // đưa vào vòng lặp duyệt từ A -> Z
                {
                    if (P[i] == vanban[j]) // nếu ký tự được duyệt của vanban giống với ký tự được duyệt của P
                    {
                        tmp_local[j] = i; // gán chỉ số của ký tự vào tmp_local
                        maso = (tmp_local[j] + khoa[j]) % P.Length; // dời sang phải chỉ số của tmp_local sang 1 số k và lấy modulo của nó với chiều dài P
                        temp[j] = P[maso]; // gán ký tự có chỉ số mới vào biến temp
                    }
                }
            }
            return new string(temp); // gán chuỗi kết quả vào ô văn bản mã hóa
        }
        public static string Giaima(string s, int[] khoa) // hàm giải mã văn bản
        {
            char[] vanban = s.ToCharArray();// chuyển các ký tự của s thành kiểu char
            int l = vanban.Length; // trả về chiều dài của chuỗi vanban
            int[] tmp_local = new int[l]; // tạo 1 danh sách đối tượng kiểu int với kích thước là chiều dài chuỗi vanban
            char[] temp = new char[l]; // tạo 1 danh sách đối tượng kiểu char với kích thước là chiều dài chuỗi vanban
            int maso; // khởi tạo biến maso
            for (int j = 0; j < l; j++) // đưa vào vòng lặp duyệt các phần tử của văn bản
            {
                for (int i = 0; i < P.Length; i++) // đưa vào vòng lặp duyệt từ A -> Z
                {
                    if (P[i] == vanban[j]) // nếu ký tự được duyệt của vanban giống với ký tự được duyệt của P
                    {
                        tmp_local[j] = i; // gán chỉ số của ký tự vào tmp_local
                        maso = ((tmp_local[j] + P.Length) - khoa[j]) % P.Length; // dời sang phải chỉ số của tmp_local sang 1 số k và lấy modulo của nó với chiều dài P
                        temp[j] = P[maso]; // gán ký tự có chỉ số mới vào biến temp
                    }
                }
            }
            return new string(temp); // gán chuỗi kết quả vào ô văn bản giải mã
        }
    }
}
