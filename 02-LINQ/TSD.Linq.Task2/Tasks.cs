using System;
using System.Collections.Generic;

public class GenericList<T>{

    List<T> list = new List<T>();
    public void Add(T input) {
        Random rnd = new Random();
        int rd = rnd.Next(2);
        if (rd == 0){ list.Insert(0,input); }
        else{ list.Add(input); }

    }

    public T get(int index) {
        Random rnd = new Random();
        int rd = rnd.Next(index+1);
        return list[rd];
    }

    public bool isEmpty() {
        return !list.Any();
    }
}
public class Tasks{

    public static void Main(string[] args){
        Console.WriteLine("Is a Leap Year ? : " + Task2(2012));

        GenericList<int> list = new GenericList<int>();

        Console.WriteLine("is Empty ? : " + list.isEmpty());

        Random rnd = new Random();
        
        for (int i=0; i< 10; i++){
            list.Add(rnd.Next(10));
        }
        
        Console.WriteLine(list.get(7));

        Console.WriteLine("is Empty ? : " + list.isEmpty());
    }

    public static bool Task2(int year){
        Func<int, bool> leapYear = x => (x % 4 == 0 && x % 100 != 0 )|| (x % 400 == 0) ;

        return leapYear(year);
    }

}