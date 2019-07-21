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

            // MobilePhone[] myMobilePhones = new MobilePhone[10];

            // for (int i = 0; i < myMobilePhones.Length; i++)
            // {
            //     myMobilePhones[i] = new MobilePhone(model, manufacturer, owner, battery, screen, 1000 + i);
            //     myMobilePhones[i].ToString();
            // }

            DateTime calldate = new DateTime(2019, 07, 19);
            DateTime callstart = new DateTime(2019, 07, 19, 10, 30, 50);
            DateTime callend = new DateTime(2019, 07, 19, 10, 33, 50);



            var phone = new MobilePhone(model, manufacturer, owner, battery, screen, 1000);

            var call = new Call(calldate, callstart, callend);

            phone.AddCallRecord(call);
            phone.AddCallRecord(call);
            phone.AddCallRecord(call);


            Console.WriteLine(phone.CallHistory.Count);

            phone.DeleteCallRecord();


            Console.WriteLine(phone.CallHistory.Count);

            phone.DeleteAllCallRecords();

            Console.WriteLine(phone.CallHistory.Count);

        }
    }

    // class CallHistoryTest
    // {
    //     private MobilePhone phone;

    //     public CallHistoryTest()
    //     {
    //         Model model = new Model("Huawei");
    //         Manufacturer manufacturer = new Manufacturer("Huawei Inc");
    //         Owner owner = new Owner("Wechuli");
    //         Battery battery = new Battery("MyBattery", 6.5, 6);
    //         Screen screen = new Screen("black", 5.5);

    //         phone = new MobilePhone(model, manufacturer, owner, battery, screen, 1000);
    //     }


    // }
}
