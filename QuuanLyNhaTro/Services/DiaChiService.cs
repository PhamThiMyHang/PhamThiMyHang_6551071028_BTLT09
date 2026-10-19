using System.Net.Http.Json;

namespace QuanLyNhaTro.Services;

public record Tinh(string name, int code);
public record PhuongXa(string name, int code);
public class TinhChiTiet
{
    public string name { get; set; } = "";
    public int code { get; set; }
    public List<PhuongXa> wards { get; set; } = new();
}

public static class DiaChiService
{
    // MỘT HttpClient dùng chung cho cả ứng dụng, Timeout 10 giây
    private static readonly HttpClient _http = new() { Timeout = TimeSpan.FromSeconds(10) };
    private const string Base = "https://provinces.open-api.vn/api/v2/";

    public static async Task<List<Tinh>> LayTinhAsync()
        => await _http.GetFromJsonAsync<List<Tinh>>(Base) ?? new();

    public static async Task<List<PhuongXa>> LayPhuongXaAsync(int maTinh)
    {
        var t = await _http.GetFromJsonAsync<TinhChiTiet>($"{Base}p/{maTinh}?depth=2");
        return t?.wards ?? new();
    }
}