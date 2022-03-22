using System;
using System.Threading;
using System.Collections.Generic;

class Program {

	static bool isrunning = true;
	
	static string password = "digits";
	static string word = "";
	const int intlimit = 2147480000;
	static int limitsreached = 0;
	static int attempts = 0;
	static int wordlength = 6;
	static Random rand = new Random();
	static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
	// static string chars = "1234567890";

	static DateTime StartingTime = DateTime.Now;
	static DateTime EndingTime;
	
	static void GeneratePassword()
	{
		string tempword = "";
		for (int i = 0; i < wordlength; i++){
			int randint = rand.Next(0, chars.Length);
			// Console.WriteLine(chars[randint]);
			tempword += chars[randint];
		}
		Console.WriteLine($"Password generated is: {tempword}");
		password = tempword;
	}

	static void FindPassword()
	{
		while(isrunning)
		{
			string tempword = "";
			for (int i = 0; i < wordlength; i++){
				int randint = rand.Next(0, chars.Length);
				// Console.WriteLine(chars[randint]);
				tempword += chars[randint];
			}

			word = tempword;

			if(attempts >= intlimit)
			{
				limitsreached++;
				attempts = 0;
			} else {
				attempts++;
			}

			if (attempts % 100000 == 0)
			{
				Console.WriteLine($"Attempts reached {attempts}");
			}
			// Console.WriteLine($"{tempword}");

			if (password == tempword && isrunning == false)
			{
				EndingTime = DateTime.Now;
				Console.WriteLine($"Found word! Word: {tempword}\n\nAttempt count: {attempts + (intlimit*limitsreached)}\n\nStartingTime: {StartingTime}\nEndingTime: {EndingTime}\nTimeDifference: {EndingTime.Subtract(StartingTime).TotalMinutes}");
				isrunning = false;
			}
		}
	}
	
  	public static void Main (string[] args) {
		// GeneratePassword();
		
		Thread t = new Thread(new ThreadStart(FindPassword));
		t.Start();

		Thread t2 = new Thread(new ThreadStart(FindPassword));
		t2.Start();

		Thread t3 = new Thread(new ThreadStart(FindPassword));
		t3.Start();

		Thread t4 = new Thread(new ThreadStart(FindPassword));
		t4.Start();

		Thread t5 = new Thread(new ThreadStart(FindPassword));
		t5.Start();

		Thread t6 = new Thread(new ThreadStart(FindPassword));
		t6.Start();

		Thread t7 = new Thread(new ThreadStart(FindPassword));
		t7.Start();

		Thread t8 = new Thread(new ThreadStart(FindPassword));
		t8.Start();

		t.Join();
		t2.Join();
		t3.Join();
		t4.Join();
		t5.Join();
		t6.Join();
		t7.Join();
		t8.Join();

		Console.WriteLine($"All threads finished.");
  	}
}