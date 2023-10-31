using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class Caesar
    {
        //public static string nguon =
        //"aáàạảãăắằặẳẵâấầậẩẫbcdđeéèẹẻẽêếềệểễfghiíìịỉĩjklmnoóòọỏõôốồộổỗơớờợởỡpqrstuúùụủũưứừựửữvwxyA
        //ÁÀẠẢÃĂẮẰẶẲẴÂẤẦẬẨẪBCDĐEÉÈẸẺẼÊẾỀỆỂỄFGHIÍÌỊỈĨJKLMNOÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠPQRSTUÚÙỤỦŨƯỨỪỰỬỮVWXY012
        //3456789~`!@#$%^&*()-_.:';,/?<>[]{}=+ ";
        public static string nguon = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // khởi tạo mảng thứ tự các ký tự chữ
        public static char[] P = nguon.ToCharArray(); // chuyển các ký tự của nguon thành kiểu char

        public static string Mahoa(string s, int k) // Hàm dùng để mã hóa
        {
            int mahoa_local = 0; // khởi tạo biến cục bộ = 0
            char[] vanban = s.ToCharArray(); // chuyển các ký tự của s thành kiểu char
            int l = vanban.Length; // trả về chiều dài của chuỗi vanban
            char[] tmp_text = new char[l]; // tạo 1 danh sách đối tượng kiểu char với kích thước là chiều dài chuỗi vanban
            int[] tmp_local = new int[l]; // tạo 1 danh sách đối tượng kiểu int với kích thước là chiều dài chuỗi vanban
            int j = 0; // khởi tạo biến j
            while (j < l) // đưa vào vòng lặp duyệt các phần tử của văn bản
            {
                for (int i = 0; i < P.Length; i++) // đưa vào vòng lặp duyệt từ A -> Z
                {
                    if (P[i] == vanban[j]) // nếu ký tự được duyệt của vanban giống với ký tự được duyệt của P
                    {
                        tmp_local[j] = i; // gán chỉ số của ký tự vào tmp_local
                        mahoa_local = tmp_local[j] + k; // dời sang phải chỉ số của tmp_local sang 1 số k
                        if (mahoa_local >= P.Length) // nếu chỉ số lớn hơn chiều dài của P
                            mahoa_local = mahoa_local - P.Length; // thì chỉ số đó trừ cho chiều dài của P
                        tmp_text[j] = P[mahoa_local]; // gán ký tự có chỉ số mới vào biến tmp_text
                    }
                }
                j++; // tăng chỉ số lên để duyệt tiếp ký tự tiếp theo của vanban
            }
            return new string(tmp_text); // gán chuỗi kết quả vào ô văn bản mã hóa
        }
        public static string GiaiMa(string s, int k) // hàm dùng để giải mã
        {
            int mahoa_local = 0; // khởi tạo biến cục bộ = 0
            char[] vanban = s.ToCharArray(); // chuyển các ký tự của s thành kiểu char
            int l = vanban.Length; // trả về chiều dài của chuỗi vanban
            char[] tmp_text = new char[l]; // tạo 1 danh sách đối tượng kiểu char với kích thước là chiều dài chuỗi vanban
            int[] tmp_local = new int[l]; // tạo 1 danh sách đối tượng kiểu int với kích thước là chiều dài chuỗi vanban
            int j = 0; // khởi tạo biến j
            while (j < l) // đưa vào vòng lặp duyệt các phần tử của văn bản
            {
                for (int i = 0; i < P.Length; i++) // đưa vào vòng lặp duyệt từ A -> Z
                {
                    if (P[i] == vanban[j]) // nếu ký tự được duyệt của vanban giống với ký tự được duyệt của P
                    {
                        tmp_local[j] = i; // gán chỉ số của ký tự vào tmp_local
                        mahoa_local = tmp_local[j] - k;  // dời sang trái chỉ số của tmp_local sang 1 số k
                        if (mahoa_local < 0) // nếu chỉ số bé hơn 0
                            mahoa_local = mahoa_local + P.Length; // thì chỉ số đó cộng thêm cho chiều dài của P
                        tmp_text[j] = P[mahoa_local]; // gán ký tự có chỉ số mới vào biến tmp_text
                    }
                }
                j++; // tăng chỉ số lên để duyệt tiếp ký tự tiếp theo của vanban
            }
            return new string(tmp_text); // gán chuỗi kết quả vào ô văn bản giải mã
        }
    }
}

