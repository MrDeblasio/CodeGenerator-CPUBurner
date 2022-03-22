using System;
using System.Threading;
using System.Collections.Generic;

class Program
{

	static bool isrunning = true;

	static string password = "hacks";
	static string word = "";
	const int intlimit = 2147480000;
	static int limitsreached = 0;
	static int attempts = 0;
	static int wordlength = 5;
	static Random rand = new Random();
	static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
	// static string chars = "1234567890";

	static DateTime StartingTime = DateTime.Now;
	static DateTime EndingTime;

	static void GeneratePassword()
	{
		string tempword = "";
		for (int i = 0; i < wordlength; i++)
		{
			int randint = rand.Next(0, chars.Length);
			// Console.WriteLine(chars[randint]);
			tempword += chars[randint];
		}
		Console.WriteLine($"Password generated is: {tempword}");
		password = tempword;
	}

	static void FindPassword()
	{
		while (isrunning)
		{
			string tempword = "";
			for (int i = 0; i < wordlength; i++)
			{
				int randint = rand.Next(0, chars.Length);
				// Console.WriteLine(chars[randint]);
				tempword += chars[randint];
			}

			word = tempword;

			if (attempts >= intlimit)
			{
				limitsreached++;
				// Console.WriteLine($"Integer limit reached, total: {limitsreached}");
				attempts = 0;
			}
			else
			{
				attempts++;
				Console.WriteLine($"{attempts}, {limitsreached}, {tempword}");
			}
			// Console.WriteLine($"{tempword}");

			if (password == tempword && isrunning == true)
			{
				EndingTime = DateTime.Now;
				// Attempt count: {attempts + (intlimit*limitsreached)}\n\
				Console.WriteLine($"Found word! Word: {tempword}\n\nStartingTime: {StartingTime}\nEndingTime: {EndingTime}\nTimeDifference: {EndingTime.Subtract(StartingTime).TotalMinutes}");
				isrunning = false;
				break;
			}
		}
	}

	public static void Main(string[] args)
	{
		// GeneratePassword();

		List<Thread> Threads = new List<Thread>();

		for (int i = 0; i < 1000; i++)
		{
			Thread t = new Thread(FindPassword);
			Threads.Add(t);
		}

		foreach (Thread t in Threads)
		{
			t.Start();
			t.Join();
		}

		Console.WriteLine($"All threads finished.");
	}
}
