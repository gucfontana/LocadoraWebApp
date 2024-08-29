using System.Text.Json;

namespace Locadora.Infra.IO.Extensions
{
    public static class FileInfoExtensions
    {
        public static async Task SerializarAsync(this FileInfo arquivo, object objeto)
        {
            JsonSerializerOptions options = new ()
            {
                WriteIndented = true
            };

            var registroEmBytes = JsonSerializer.SerializeToUtf8Bytes(objeto, options);

            await File.WriteAllBytesAsync(arquivo.FullName, registroEmBytes);
        }

        public static async Task<T ?> DeserializarAsync<T>(this FileInfo arquivo)
        {
            var registrosEmBytes = await File.ReadAllBytesAsync(arquivo.FullName);

            return JsonSerializer.Deserialize<T>(registrosEmBytes);
        }
    }
}