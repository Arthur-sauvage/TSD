using TSD.Linq.Task1.Lib;
using TSD.Linq.Task1.Lib.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Tasks{

    public static void Main(string[] args){
        Task2();
        Console.WriteLine();
        Task3();
        Console.WriteLine();
        Task4();

    /*    Console.WriteLine();
        Task8();
        Console.WriteLine();
        Task9();*/

    //    Task12();

     /*   XDocument xdoc = XDocument.Load("C:\\Users\\Arthur Sauvage\\Documents\\Tp_Pologne\\TSD\\02-LINQ\\TSD.Linq.Task1\\List_Prices.xml");
        Task13(xdoc);*/
        
    }

    public static void Task2(){
        GoldClient goldClient = new GoldClient();

        DateTime startDate = new DateTime(2021, 01, 01);
        DateTime endDate = new DateTime(2021, 12, 31);
        List<GoldPrice> lastYearPrices = goldClient.GetGoldPrices(startDate, endDate).GetAwaiter().GetResult();

        var max = (from gold in lastYearPrices
                    orderby gold.Price descending
                    select gold.Price).Take(3);

        Console.WriteLine("TOP 3 highest prices of gold within the last year");
        foreach ( double m in max){
            Console.WriteLine(m);
        }

        var min = (from gold in lastYearPrices
                    orderby gold.Price
                    select gold.Price).Take(3);

        Console.WriteLine("TOP 3 lowest prices of gold within the last year");
        foreach ( double m in min){
            Console.WriteLine(m);
        }
        
    }

    public static void Task3(){
        
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> Goldjanuary2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), 
                                                                   new DateTime(2020, 01, 31)).GetAwaiter().GetResult();
            
        var january = (from gold in Goldjanuary2020
                    orderby gold.Price
                    select gold).Take(1);

        foreach ( var j in january){
            Console.WriteLine("January lowest point :    Date : " + j.Date + " Price : " + j.Price);

            List<GoldPrice> Goldsincejanuary2020 = goldClient.GetGoldPrices(j.Date, new DateTime(2020, 01, 31)).GetAwaiter().GetResult();
            
            var gain = (from gold in Goldsincejanuary2020
                    where gold.Price > j.Price * 1.05
                    select gold).Take(1);

            foreach ( var g in gain){
                Console.WriteLine("Gain more than 5% :    Date : " + g.Date + " Price : " + g.Price);
            }
        }
    }

    public static void Task4(){
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> gold_2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
        
        gold_2019.AddRange(gold_2020);
        gold_2019.AddRange(gold_2021);

        var max = (from gold in gold_2019
                    orderby gold.Price descending
                    select gold).Take(13);

        Console.WriteLine("3 dates of 2021-2019 which opens the second ten of the prices ranking :");

        int i = 0;
        foreach ( var m in max){
            if (i>9){
                Console.WriteLine("Date : " + m.Date + " Price : " + m.Price);
            }
            i++;
        }
    }

    public static void Task8(){

        GoldClient goldClient = new GoldClient();

        List<GoldPrice> gold_2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();

        var average2019 = (from gold in gold_2019
                            select gold.Price).Average();
        
        var average2020 = (from gold in gold_2020
                            select gold.Price).Average();

        var average2021 = (from gold in gold_2021
                            select gold.Price).Average();

        Console.WriteLine("The averages of gold prices in 2019, 2020, 2021 are : ");
        Console.WriteLine("2019 : " + average2019);
        Console.WriteLine("2020 : " + average2020);
        Console.WriteLine("2021 : " + average2021);
    }

    public static void Task9(){
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> gold_2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
    
        gold_2019.AddRange(gold_2020);
        gold_2019.AddRange(gold_2021);

        var min = (from gold in gold_2019
                    orderby gold.Price
                    select gold).Take(1);

        var max = (from gold in gold_2019
                    orderby gold.Price descending
                    select gold).Take(1);

        foreach ( var m in min){
            Console.WriteLine("Best day to buy Gold : Date : " + m.Date + " Price : " + m.Price);

            foreach ( var ma in max){
                Console.WriteLine("Best day to sell Gold : Date : " + ma.Date + " Price : " + ma.Price);

                Console.WriteLine("The return on investment : " + (ma.Price/m.Price-1)*100 + " %");
            }
        }
    }

    public static void Task12(){
        GoldClient goldClient = new GoldClient();

        List<GoldPrice> gold_2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        List<GoldPrice> gold_2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();

        gold_2019.AddRange(gold_2020);
        gold_2019.AddRange(gold_2021);

        try
        {
            var xEle = new XElement("List_of_prices",
                        from gold in gold_2019
                        select new XElement("Gold",
                                    new XElement("Date", gold.Date),
                                    new XElement("Price", gold.Price)
                                ));

        
            xEle.Save("C:\\Users\\Arthur Sauvage\\Documents\\Tp_Pologne\\TSD\\02-LINQ\\TSD.Linq.Task1\\List_Prices.xml");
            Console.WriteLine("Converted to XML");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }

    public static void Task13(XDocument xdoc){

        foreach (var gold in xdoc.Root.Elements()){
            Console.WriteLine("Date : {0}  Price : {1}",
                                gold.Element("Date").Value,
                                gold.Element("Price").Value);
        }
        
    }

    
}