using System;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            // MobilePhone.DisplayStaticModelInfo();

            Model model = new Model("Huawei");
            Manufacturer manufacturer = new Manufacturer("Huawei Inc");
            Owner owner = new Owner("Wechuli");
            Battery battery = new Battery("MyBattery", 6.5, 6);
            Screen screen = new Screen("black", 5.5);

            MobilePhone[] myMobilePhones = new MobilePhone[10];

            for (int i = 0; i < myMobilePhones.Length; i++)
            {
                myMobilePhones[i] = new MobilePhone(model, manufacturer, owner, battery, screen, 1000 + i);
                myMobilePhones[i].ToString();
            }




        }
    }
}
