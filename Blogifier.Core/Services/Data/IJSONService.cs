namespace Blogifier.Core.Services
{
	public interface IJSONService
	{
		T JSONStringToObject<T>(string json);
		string ObjectToJSONString(object obj);
	}
}