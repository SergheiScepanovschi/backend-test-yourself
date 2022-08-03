using System;
using System.Collections.Generic;

namespace ConsoleApp1
{

	public class Program
	{
		public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
		{
			var result = new List<B>();
			if(list == null)
				throw new NullReferenceException("Map listA");
			if (f == null)
				throw new NullReferenceException("Map func");
			foreach (var item in list)
			{
				result.Add(f(item));
			}
			return result;
		}
		
		public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
		{
			B temp = initial;
			if (initial == null)
				throw new NullReferenceException("Fold initial");
			if (list == null)
				throw new NullReferenceException("Fold listA");
			if (folder == null)
				throw new NullReferenceException("Fold folder");
			foreach (var item in list)
			{
				temp = folder(temp, item);
			}
			return temp;
		}
		public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
		{
			if (list == null)
				throw new NullReferenceException("Map2 listA");
			if (f == null)
				throw new NullReferenceException("Map2 func");
			var result = Fold(list, new List<B>(), (listNew, x) =>
			{
				listNew.Add(f(x));
				return listNew;
			});
		
		
			return result;
		}
		static void Main(string[] args)
		{
			List<int> emptyList = new List<int>();
			List<int> listInitial = new List<int>{ 2, 3, 4};
			
			var resultMapList = Map<int, int>(listInitial, x => x + 1);
			var resultMapListStr = Map(listInitial, x => x.ToString()); 
			
			var resultFold = Fold(listInitial, 0, (sum, x) => sum + x); 
			var resultFoldStr = Fold(listInitial, "", (str, x) => str + x.ToString());
			
			var resultsMap2 = Map2(listInitial, x => x + 5);
		
		}
	}
}
