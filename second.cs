using System;
class NumberName{
	static readonly string[] digit = {"","one","two","three","four","five","six","seven","eight","nine"};
	static readonly string[] tens = {"","","twenty","thirty","fourty","fifty","sixty","seventy","eighty","ninety"};
	static readonly string[] teen = {"ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};

	public static string GetName(long i)
	{
		if(i == 0) return "zero";
		if(i < 100) return digit2 (i);
		else if(i < 1000) return digit3(i);
		else if(i < 1000000) return digit6(i);
		else if(i < 1000000000) return digit9(i);
		else return digit[i/1000000000] +" billion "+digit9(i%1000000000);
	}
	private static string digit2(long i)
	{
		if (i < 10) return digit[i];
		else if(i < 20) return teen[i%10];
		else if(i%10 == 0) return tens[i/10];
	    else return tens[i/10]+" "+digit[i%10];
	}
	private static string digit3(long i)
	{
		if(i < 100) return digit2 (i);
	    return digit[i/100]+" hundred "+digit2(i%100);
	}
	private static string digit6(long i){
		if(i < 1000) return digit3(i);
	    return digit3(i/1000)+" thousand "+digit3(i%1000);
	}
	private static string digit9 (long i)
	{
		if(i < 1000000) return digit6(i);
		return digit3 (i/1000000)+" million "+digit6(i%1000000);
	}
}
class Program{
	static void Main (string[] args)
	{
		while (true) {
			Console.WriteLine("Please enter an number(less than ten billion): ");
			string str = Console.ReadLine().ToLower();
			if(str == "halt"){break;}
            Console.WriteLine("The number you enter is: "+str);
			long num = 0;
			if(!Int64.TryParse(str,out num) || str.Length >= 11 ){Console.WriteLine("You input invalid number.Try again.");continue;}
			Console.WriteLine(NumberName.GetName(num));
		}
	}
}