using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_thu_cung
{
    public class Animals
    {
        public string id;
        public string name;
        public float height;
        public float weight;
        public string color;

        public string getID()
        {
            return id;
        }
        public void setID(string newID)
        {
            if(newID.Length==0)
            {
                Console.WriteLine("ID khong hop le! ");

            }    
            else
            {
                this.id = newID;
            }    
        }

        public string getName()
        {
            return name;
        }
        public void setName(string newName)
        {
            if (newName.Length == 0)
            {
                Console.WriteLine("Ten khong hop le! ");

            }
            else
            {
                this.name = newName;
            }
        }

        
        public float getHeight()
        {
              
            return height;
        }
        public void setHeight(float newHeight)
        {
            if (newHeight <= 0 )
            {    
                Console.WriteLine("Chieu cao khong hop le! ");

            }
            else
            {
                this.height = newHeight;
            }
        }

        public float getWeight()
        {
            return weight ;
        }
        public void setWeight(float newWeight)
        {
            if (newWeight <= 0)
            {
                Console.WriteLine("Can nang khong hop le! ");

            }
            else
            {
                this.weight = newWeight;
            }
        }

        public string getColor()
        {
            return color;
        }
        public void setColor(string newColor)
        {
            if (newColor.Length == 0)
            {
                Console.WriteLine("Mau khong hop le! ");

            }
            else
            {
                this.color = newColor;
            }
        }

        public Animals()
        {

        }

        public Animals( string id,string name,float height,float weight,string color)
        {
            this.id = id;
            this.name = name;
            this.height = height;
            this.weight = weight;
            this.color = color;
        }

        public void Input(List<Animals> animals)
        {
            Console.WriteLine("Nhap Id: ");
            id = Console.ReadLine();
            var check = false;
            foreach (var animal in animals)
            {
                if(animal.id == id)
                {
                    Console.WriteLine($"Id {id} da ton tai");
                    check = true;
                }
            }

            if(check==false  )
            {
                
                Console.WriteLine("Nhap ID: ");
                id = Console.ReadLine();
            }
          


            Console.WriteLine("Nhap ten: ");
            name = Console.ReadLine();
            
            Console.WriteLine("Nhap chieu cao: ");
            height= float.Parse(Console.ReadLine());
            while(height<=0)
            {
                Console.WriteLine("Chieu cao khong thich hop!");
                Console.WriteLine("Nhap chieu cao: ");
                height = float.Parse(Console.ReadLine());
            }
            
            Console.WriteLine("Nhap can nang: ");
            weight= float.Parse(Console.ReadLine());
            while (weight <= 0)
            {
                Console.WriteLine("Can nang khong thich hop!");
                Console.WriteLine("Nhap can nang: ");
                weight = float.Parse(Console.ReadLine());
            }

            Console.WriteLine("Nhap mau sac: ");
            color= Console.ReadLine();

        }

        public virtual void Output()
        {
            Console.WriteLine($"ID {this.id} _ Ten {this.name} _ Chieu cao {this.height} _ can nang {this.weight} _ mau sac {this.color}");
        }
    }
}
