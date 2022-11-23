using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_thu_cung
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            List<Animals> lstAnimal = new List<Animals>();
            lstAnimal.Add(new Animals("Dog1", "Husky", 110, 50, "Yellow"));
            lstAnimal.Add(new Animals("Cat1", "Yellow cat", 50, 20, "Yellow"));
            lstAnimal.Add(new Dog("Dog2","Pit Pull",150,50,"Orange "));
            lstAnimal.Add(new Pig("Pig1", "Pink", 150, 100, "Pink "));
            lstAnimal.Add(new Chicken("Chic1", "Small Chick", 50, 5, "Yellow "));


            Console.WriteLine("Case 1: Xem danh sach thu cung");
            Console.WriteLine("Case 2: Them danh sach thu cung");  
            Console.WriteLine("Case 3: Sua danh sach thu cung");
            Console.WriteLine("Case 4: Xoa danh sach thu cung");
            
            
            int n;
            Console.WriteLine("Nhap so:");
            n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    foreach (Animals item in lstAnimal)
                    {
                        Console.WriteLine($"{item.getID()}_{item.getName()}_{item.getHeight()}_{item.getWeight()}_{item.getColor()}");
                    }
                    break;

                case 2:
                    lstAnimal.Add(new Animals());
                    Animals animal1 = new Animals();
                    animal1.Input(lstAnimal);
                    animal1.Output();
                    break;
                case 3:
                    string inputID;
                    Console.WriteLine("Nhap id pet cua ban: ");
                    inputID = Console.ReadLine();
                    var check = false;
                    foreach (var item in lstAnimal)
                    {
                            if (item.getID()==inputID)
                        {
                            string newName;
                            Console.WriteLine("Nhap ten pet moi: ");
                            newName=Console.ReadLine();
                            item.setName(newName);

                            float newHeight;
                            Console.WriteLine("Nhap chieu cao pet moi: ");
                            newHeight = float.Parse(Console.ReadLine());
                            item.setHeight(newHeight);

                            float newWeight;
                            Console.WriteLine("Nhap can nang pet moi: ");
                            newWeight = float.Parse(Console.ReadLine());
                            item.setWeight(newWeight);

                            string newColor;
                            Console.WriteLine("Nhap mau long pet moi: ");
                            newColor = Console.ReadLine();
                            item.setColor(newColor);
                            
                            Console.WriteLine("Thong tin pet moi: ");
                            item.Output();
                            check = true;
                        }
                             
                    }
                    if (check==false)
                        {
                            Console.WriteLine("ID khong ton tai");
                            
                        }   
                       
                    break;

                case 4:
                    string removeID;
                    Console.WriteLine("Nhap ID pet can xoa: ");
                    removeID = Console.ReadLine();

                    var check1 = false;
                    foreach (var item in lstAnimal.ToList())
                    {
                        if (item.getID() == removeID)
                        {
                            lstAnimal.Remove(item);
                            Console.WriteLine("Da xoa pet!");
                            check1 = true;
                            break;
                        }


                    }
                    if (check1 == false)
                        {
                            Console.WriteLine("ID khong ton tai");
                        }


                    break;

                default:
                    Console.WriteLine("Nhap sai !");
                    break;


            }

            
            
            Console.ReadKey();
        }
    }
}
