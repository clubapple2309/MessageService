using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net;

namespace MessageService.Api.Models.Response
{
	public class JsonResponse
	{
		public int StatusCode { get; set; }
		public string Text { get; set; }
		public object Data { get; set; }

		protected JsonResponse(int statusCode, string text, object data)
		{
			StatusCode = statusCode;
			Text = text;
			Data = data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static JsonResponse GetSuccessResult(string message = "", object data = null) =>
			new JsonResponse(200, message, data);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static JsonResponse GetFailedResult(string message = "", object data = null) =>
			new JsonResponse(500, message, data);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static JsonResponse GetRequestResult(HttpStatusCode code, string message = "", object data = null) =>
			new JsonResponse((int)code, message, data);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static JsonResponse GetBadRequestResult(string message = "", object data = null) =>
			new JsonResponse(400, message, data);

	}
}
