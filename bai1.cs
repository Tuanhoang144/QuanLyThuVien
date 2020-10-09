using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace baitaplttq
{
    class CanBo
    {
        protected string hoten, diachi;
        protected int namsinh;
        protected bool gioitinh;
        public string getTen()
        {
            return hoten;
        }
        public CanBo(string hoten1, string diachi1, int namsinh1, bool gioitinh1)
        {
            this.hoten = hoten1;
            this.diachi = diachi1;
            this.namsinh = namsinh1;
            this.gioitinh = gioitinh1;
        }
        public CanBo()
        {

        }
        public virtual void Nhap()
        {
            Console.Write("Nhap ho ten:"); hoten = Console.ReadLine();
     
        nhan1:
            Console.Write("Nhap gioi tinh:");
            string temp2 = Console.ReadLine();
            if (temp2 == "nam")
            {
                gioitinh = true;
            } else if (temp2 == "nu")
            {
                gioitinh = false;
            } else
            {
                Console.WriteLine("Gioi tinh khong hop le! Hay nhap nam/nu");
                goto nhan1;
            }
        nhan2:
            Console.Write("Nhap nam sinh:");
            string temp = Console.ReadLine();
            if (int.TryParse(temp, out namsinh))
            {
                namsinh = int.Parse(temp);
            } else
            {
                Console.WriteLine("Nam sinh khong hop le! Hay nhap lai");
                goto nhan2;
            }
            Console.Write("Nhap dia chi:"); diachi = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine("Ho ten: {0}", hoten);
            Console.WriteLine("Gioi tinh: {0}", gioitinh);
            Console.WriteLine("Nam sinh: {0}", namsinh);
            Console.WriteLine("Dia chi: {0}", diachi);
        }
    }
    class NhanVien : CanBo
    {
        private string congViec;
        public NhanVien(string hoten1, string diachi1, int namsinh1, bool gioitinh1, string congViec1) : base(hoten1,diachi1,namsinh1,gioitinh1)
        {
            this.congViec = congViec1;
        }
        public NhanVien() : base()
        {

        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap cong viec: "); congViec = Console.ReadLine();
        }
        public void HienThi()
        {
            base.HienThi();
            Console.WriteLine("Cong viec: {0}", congViec);
        }
    }
    class CongNhan : CanBo
    {
        private string bac;
        public CongNhan(string hoten1, string diachi1, int namsinh1, bool gioitinh1, string bac1) : base(hoten1, diachi1, namsinh1, gioitinh1)
        {
            this.bac = bac1;
        }
        public CongNhan() : base()
        {

        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap bac: "); bac = Console.ReadLine();
        }
        public void HienThi()
        {
            base.HienThi();
            Console.WriteLine("Bac: {0}", bac);
        }
    }
    class KySu : CanBo
    {
        private string nganhDaoTao;
        public KySu(string hoten1, string diachi1, int namsinh1, bool gioitinh1, string nganhDaoTao1) : base(hoten1, diachi1, namsinh1, gioitinh1)
        {
            this.nganhDaoTao = nganhDaoTao1;
        }
        public KySu() : base()
        {

        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap nganh dao tao: "); nganhDaoTao = Console.ReadLine();
        }
        public void HienThi()
        {
            base.HienThi();
            Console.WriteLine("Nganh dao tao: {0}", nganhDaoTao);
        }
    }
    class bai1
    {
        static void Main(String []arg)
        {
            ArrayList list = new ArrayList();
        nhan3:
            Console.Clear();
            bai1.Menu();
            int choice;
            Console.Write("Moi chon chuc nang: ");
            choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    int choice2;
                    Console.Clear();
                    Console.WriteLine("----- MENU -----");
                    Console.WriteLine("1. Ky su");
                    Console.WriteLine("2. Nhan vien");
                    Console.WriteLine("3. Cong nhan");
                    Console.WriteLine("4. Quay lai");
                    Console.Write("Chon can bo can nhap: ");
                    choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Nhap so luong ky su: "); int n = int.Parse(Console.ReadLine());
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine("Nhap ky su thu {0}: ",i+1);
                                KySu temp = new KySu();
                                temp.Nhap();
                                list.Add(temp);
                            }
                            goto nhan3;
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("Nhap so luong nhan vien: "); 
                            int n2 = int.Parse(Console.ReadLine());
                            for (int i = 0; i < n2; i++)
                            {
                                Console.WriteLine("Nhap nhan vien thu {0}: ", i + 1);
                                NhanVien temp = new NhanVien();
                                temp.Nhap();
                                list.Add(temp);
                            }
                            goto nhan3;
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Nhap so luong cong nhan: "); int n3 = int.Parse(Console.ReadLine());
                            for (int i = 0; i < n3; i++)
                            {
                                Console.WriteLine("Nhap cong nhan thu {0}: ", i + 1);
                                CongNhan temp = new CongNhan();
                                temp.Nhap();
                                list.Add(temp);
                            }
                            goto nhan3;
                            break;
                        case 4: goto nhan3;
                        default: break;
                    }
                    break;
                case 2:
                    Console.Write("Nhap ten can bo can tim kiem: ");
                    string ten = Console.ReadLine();
                    int dem = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (((CanBo)list[i]).getTen().Contains(ten))
                        {
                            dem++;
                            ((CanBo)list[i]).HienThi();
                        }
                    }
                    if (dem == 0)
                    {
                        Console.WriteLine("Khong co can bo nay! ");
                    }
                    Console.ReadKey();
                    goto nhan3;
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("----- DANH SACH CAN BO -----"); Console.WriteLine();
                    foreach (var item in list)
                    {
                        ((CanBo)item).HienThi();
                    }
                    Console.ReadKey();
                    goto nhan3;
                    break;               
                case 4: break;
                default: break;
            }
            
        }
        static void Menu()
        {
            Console.WriteLine("--------- MENU ----------");
            Console.WriteLine("1. Nhap thong tin can bo");
            Console.WriteLine("2. Tim kiem theo ho ten");
            Console.WriteLine("3. Hien thi danh sach can bo");
            Console.WriteLine("4. Thoat chuong trinh");
        }
    }
}
