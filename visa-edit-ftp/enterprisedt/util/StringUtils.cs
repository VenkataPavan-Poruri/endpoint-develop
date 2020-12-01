using System;
using System.Collections.Generic;
using System.Text;

namespace visa_edit_ftp.enterprisedt.util
{
	public class StringUtils
	{

		private const int MAX_FIELDS = 100;

		private static StringUtils utils = new StringUtils();

		/// <summary>
		/// Replaces all occurrences of 'from' in 'text' with 'to'.  Used when writing code
		/// for JDK 1.1.
		/// </summary>
		/// <param name="text"> String to replace substrings in. </param>
		/// <param name="from"> String to search for. </param>
		/// <param name="to"> String to replace with. </param>
		/// <returns> String with all occurrences of 'from' substituted with 'to'. </returns>
		public static string replaceAll(string text, string from, string to)
		{
			StringBuilder result = new StringBuilder();
			int cursor = 0; // start at the beginning
			while (true)
			{
				int fromPos = text.IndexOf(from, cursor, StringComparison.Ordinal); // find next 'from' string
				if (fromPos >= 0)
				{ // if we find one...
					result.Append(text.Substring(cursor, fromPos - cursor)); //   then copy stuff before it
					result.Append(to); //   and the 'to' string
					cursor = fromPos + from.Length; //   and skip the rest of the 'from' string
				}
				else
				{ // otherwise...
					if (cursor < text.Length) //   if we're not at the end
					{
						result.Append(text.Substring(cursor)); //      then copy the rest of the string
					}
					break; //      and finish
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Splits string consisting of fields separated by
		/// whitespace into an array of strings. Yes, we could
		/// use String.split() but this would restrict us to 1.4+
		/// </summary>
		/// <param name="str">   string to split </param>
		/// <returns> array of fields </returns>
		public static string[] split(string str)
		{
			return split(str, new WhitespaceSplitter(utils));
		}

		/// <summary>
		/// Splits string consisting of fields separated by
		/// whitespace into an array of strings. Yes, we could
		/// use String.split() but this would restrict us to 1.4+
		/// </summary>
		/// <param name="str">   string to split </param>
		/// <returns> array of fields </returns>
		public static string[] split(string str, char token)
		{
			return split(str, new CharSplitter(utils, token));
		}
		/// <summary>
		/// Splits string consisting of fields separated by
		/// whitespace into an array of strings. Yes, we could
		/// use String.split() but this would restrict us to 1.4+
		/// </summary>
		/// <param name="str">   string to split </param>
		/// <returns> array of fields </returns>
		private static string[] split(string str, Splitter splitter)
		{
			string[] fields = new string[MAX_FIELDS];
			int pos = 0;
			StringBuilder field = new StringBuilder();
			for (int i = 0; i < str.Length; i++)
			{
				char ch = str[i];
				if (!splitter.isSeparator(ch))
				{
					field.Append(ch);
				}
				else
				{
					if (field.Length > 0)
					{
						fields[pos++] = field.ToString();
						field.Length = 0;
					}
				}
			}
			// pick up last field
			if (field.Length > 0)
			{
				fields[pos++] = field.ToString();
			}
			string[] result = new string[pos];
			Array.Copy(fields, 0, result, 0, pos);
			return result;
		}


		public interface Splitter
		{
			bool isSeparator(char ch);
		}

		public class CharSplitter : Splitter
		{
			private readonly StringUtils outerInstance;

			internal char token;

			internal CharSplitter(StringUtils outerInstance, char token)
			{
				this.outerInstance = outerInstance;
				this.token = token;
			}

			public virtual bool isSeparator(char ch)
			{
				if (ch == token)
				{
					return true;
				}
				return false;
			}

		}

		public class WhitespaceSplitter : Splitter
		{
			private readonly StringUtils outerInstance;

			public WhitespaceSplitter(StringUtils outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public virtual bool isSeparator(char ch)
			{
				if (char.IsWhiteSpace(ch))
				{
					return true;
				}
				return false;
			}
		}
	}
}
