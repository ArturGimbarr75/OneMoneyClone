using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneMoneyCloneServer.Models.Server;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace OneMoneyCloneServer.Persistence.EntityConfigurations;

internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
	private const string CURRENCY_FILE_NAME = "currencies.json";

	public void Configure(EntityTypeBuilder<Currency> builder)
	{
		builder.ToTable("Currencies");
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
		builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
		builder.Property(c => c.Symbol).IsRequired().HasMaxLength(10);

		var currencies = LoadCurrenciesFromJson();
		builder.HasData(currencies);
	}

	private IEnumerable<Currency> LoadCurrenciesFromJson()
	{
		string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CURRENCY_FILE_NAME);

		if (!File.Exists(filePath))
		{
			throw new FileNotFoundException($"Currency file not found: {filePath}");
		}

		string json = File.ReadAllText(filePath);

		var currencyList = JsonSerializer.Deserialize<List<Currency>>(json)
			?? throw new InvalidOperationException("Failed to load currencies from json file");

		foreach (var currency in currencyList)
		{
			currency.Id = GenerateDeterministicGuid(currency.Code);
		}

		return currencyList;
	}

	private Guid GenerateDeterministicGuid(string input)
	{
		using (var md5 = MD5.Create())
		{
			byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
			return new Guid(hash);
		}
	}
}
