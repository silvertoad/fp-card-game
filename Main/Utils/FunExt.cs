using System;

namespace Main.Utils
{
	public static class FunExt
	{
		public static TOut Map<TOut, TIn>(this TIn source, Func<TIn, TOut> transform)
		{
			return transform(source);
		}

		public static TOut Map<TOut, TIn, TParam>(this TIn source, TParam param, Func<TIn, TParam, TOut> transform)
		{
			return transform(source, param);
		}

		public static TRet Passthrough<TRet>(this TRet source, Action<TRet> call) 
		{
			call(source);
			return source;
		}
	}
}