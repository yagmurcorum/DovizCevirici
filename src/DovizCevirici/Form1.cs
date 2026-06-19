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

        ConfigurePopularRatesGrid();
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
    /// Handles the form load event and loads popular exchange rates automatically.
    /// </summary>
    private async void Form1_Load(object? sender, EventArgs e)
    {
        await LoadPopularRatesAsync();
    }

    /// <summary>
    /// Loads popular exchange rates into the DataGridView.
    /// </summary>
    private async Task LoadPopularRatesAsync()
    {
        try
        {
            List<ExchangeRateResponse> popularRates =
                await _conversionService.GetPopularRatesAsync();

            dgvPopularRates.DataSource = popularRates
                .Select(rate => new
                {
                    Date = rate.Date.ToString("yyyy-MM-dd"),
                    rate.Base,
                    rate.Quote,
                    rate.Rate
                })
                .ToList();

            UpdatePopularRatesGridHeaders();
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }

    /// <summary>
    /// Configures the popular rates DataGridView.
    /// </summary>
    private void ConfigurePopularRatesGrid()
    {
        dgvPopularRates.ReadOnly = true;
        dgvPopularRates.AllowUserToAddRows = false;
        dgvPopularRates.AllowUserToDeleteRows = false;
        dgvPopularRates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPopularRates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPopularRates.MultiSelect = false;
        dgvPopularRates.RowHeadersVisible = false;
    }

    /// <summary>
    /// Updates DataGridView column headers for better readability.
    /// </summary>
    private void UpdatePopularRatesGridHeaders()
    {
        if (dgvPopularRates.Columns.Count == 0)
        {
            return;
        }

        dgvPopularRates.Columns["Date"].HeaderText = "Tarih";
        dgvPopularRates.Columns["Base"].HeaderText = "Kaynak";
        dgvPopularRates.Columns["Quote"].HeaderText = "Hedef";
        dgvPopularRates.Columns["Rate"].HeaderText = "Kur";

        dgvPopularRates.Columns["Date"].FillWeight = 120;
        dgvPopularRates.Columns["Base"].FillWeight = 80;
        dgvPopularRates.Columns["Quote"].FillWeight = 80;
        dgvPopularRates.Columns["Rate"].FillWeight = 100;

        dgvPopularRates.Columns["Rate"].DefaultCellStyle.Format = "N5";
        dgvPopularRates.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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