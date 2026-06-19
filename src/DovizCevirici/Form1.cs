using System.Globalization;
using DovizCevirici.Application;
using DovizCevirici.Domain.Models;

namespace DovizCevirici;

public partial class Form1 : Form
{
    private readonly CurrencyConversionService _conversionService;

    public Form1()
    {
        InitializeComponent();

        _conversionService = new CurrencyConversionService();

        InitializeCurrencyComboBoxes();

        AcceptButton = btnConvert;

        btnConvert.Click += btnConvert_Click;
    }

    /// <summary>
    /// Loads supported currency codes into the source and target currency ComboBoxes.
    /// </summary>
    private void InitializeCurrencyComboBoxes()
    {
        string[] currencies =
        {
            "USD",
            "TRY",
            "EUR",
            "GBP",
            "CHF",
            "JPY"
        };

        cmbSourceCurrency.Items.AddRange(currencies);
        cmbTargetCurrency.Items.AddRange(currencies);

        cmbSourceCurrency.SelectedItem = "USD";
        cmbTargetCurrency.SelectedItem = "TRY";

        cmbSourceCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTargetCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    /// <summary>
    /// Handles the convert button click event.
    /// </summary>
    private async void btnConvert_Click(object? sender, EventArgs e)
    {
        try
        {
            btnConvert.Enabled = false;
            lblResult.Text = "İşlem yapılıyor...";

            if (!TryReadAmount(out decimal amount))
            {
                ShowWarningMessage("Tutar sayısal bir değer olmalıdır.");
                lblResult.Text = "Sonuç burada gösterilecek.";
                return;
            }

            ConversionRequest request = new ConversionRequest
            {
                SourceCurrency = cmbSourceCurrency.SelectedItem?.ToString() ?? string.Empty,
                TargetCurrency = cmbTargetCurrency.SelectedItem?.ToString() ?? string.Empty,
                Amount = amount
            };

            ConversionResult result = await _conversionService.ConvertAsync(request);

            lblResult.Text = result.DisplayText;
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message);
            lblResult.Text = "İşlem tamamlanamadı.";
        }
        finally
        {
            btnConvert.Enabled = true;
        }
    }

    /// <summary>
    /// Reads and parses the amount entered by the user.
    /// </summary>
    private bool TryReadAmount(out decimal amount)
    {
        string input = txtAmount.Text.Trim();

        return decimal.TryParse(
                   input,
                   NumberStyles.Number,
                   CultureInfo.CurrentCulture,
                   out amount)
               ||
               decimal.TryParse(
                   input,
                   NumberStyles.Number,
                   CultureInfo.InvariantCulture,
                   out amount);
    }

    /// <summary>
    /// Shows a warning message to the user.
    /// </summary>
    private static void ShowWarningMessage(string message)
    {
        MessageBox.Show(
            message,
            "Uyarı",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    /// <summary>
    /// Shows an error message to the user.
    /// </summary>
    private static void ShowErrorMessage(string message)
    {
        MessageBox.Show(
            message,
            "Hata",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}