using Newtonsoft.Json;

namespace CTRLInvesting.Model.Stocks;

public class StockDataDetails
{
    // [JsonProperty(PropertyName = "52WeekChange")]
    // public double? _52WeekChange { get; set; }
    // public double? SandP52WeekChange { get; set; }
    // public string Address1 { get; set; }
    // public string Address2 { get; set; }
    // public double? Ask { get; set; }
    // public int? AuditRisk { get; set; }
    // public long? AverageDailyVolume10Day { get; set; }
    // public long? AverageVolume { get; set; }
    // public long? AverageVolume10Days { get; set; }
    // public double? Beta { get; set; }
    // public double? Bid { get; set; }
    // public int? BoardRisk { get; set; }
    // public double? BookValue { get; set; }
    // public string City { get; set; }
    // public int? CompensationRisk { get; set; }
    // public string Country { get; set; }
    public string Currency { get; set; }
    public double? CurrentPrice { get; set; }
    // public double? CurrentRatio { get; set; }
    // public double? DebtToEquity { get; set; }
    // public double? DividendRate { get; set; }
    public double? DividendYield { get; set; }
    // public double? EarningsGrowth { get; set; }
    // public double? EarningsQuarterlyGrowth { get; set; }
    public long? Ebitda { get; set; }
    // public double? EbitdaMargins { get; set; }
    // public double? EnterpriseToEbitda { get; set; }
    // public double? EnterpriseToRevenue { get; set; }
    // public long? EnterpriseValue { get; set; }
    // public long? ExDividendDate { get; set; }
    // public string Exchange { get; set; }
    // public double? FiftyDayAverage { get; set; }
    // public double? FiftyTwoWeekHigh { get; set; }
    // public string FinancialCurrency { get; set; }
    // public long? FirstTradeDateEpochUtc { get; set; }
    // public double? FiveYearAvgDividendYield { get; set; }
    // public long? FloatShares { get; set; }
    // public double? ForwardEps { get; set; }
    // public double? ForwardPE { get; set; }
    // public long? FreeCashflow { get; set; }
    // public int? FullTimeEmployees { get; set; }
    // public int? GmtOffSetMilliseconds { get; set; }
    // public long? GovernanceEpochDate { get; set; }
    // public double? GrossMargins { get; set; }
    // public double? HeldPercentInsiders { get; set; }
    // public double? HeldPercentInstitutions { get; set; }
    // public long? ImpliedSharesOutstanding { get; set; }
    // public string Industry { get; set; }
    // public string IndustryDisp { get; set; }
    // public string IndustryKey { get; set; }
    public long? LastDividendDate { get; set; }
    public double? LastDividendValue { get; set; }
    // public long? LastFiscalYearEnd { get; set; }
    // public long? LastSplitDate { get; set; }
    // public string LastSplitFactor { get; set; }
    // public string LongBusinessSummary { get; set; }
    public string LongName { get; set; }
    // public long? MarketCap { get; set; }
    // public int? MaxAge { get; set; }
    // public string MessageBoardId { get; set; }
    // public long? MostRecentQuarter { get; set; }
    // public long? NetIncomeToCommon { get; set; }
    // public long? NextFiscalYearEnd { get; set; }
    // public int? NumberOfAnalystOpinions { get; set; }
    // public double? OperatingCashflow { get; set; }
    // public double? OperatingMargins { get; set; }
    // public int? OverallRisk { get; set; }
    // public double? PayoutRatio { get; set; }
    // public double? PegRatio { get; set; }
    // public string Phone { get; set; }
    // public double? PreviousClose { get; set; }
    // public int? PriceHint { get; set; }
    // public double? PriceToBook { get; set; }
    // public double? PriceToSalesTrailing12Months { get; set; }
    // public double? ProfitMargins { get; set; }
    // public double? QuickRatio { get; set; }
    // public string QuoteType { get; set; }
    // public string RecommendationKey { get; set; }
    // public double? RecommendationMean { get; set; }
    // public double? RegularMarketPreviousClose { get; set; }
    // public double? ReturnOnAssets { get; set; }
    // public double? ReturnOnEquity { get; set; }
    // public double? RevenueGrowth { get; set; }
    // public double? RevenuePerShare { get; set; }
    // public string Sector { get; set; }
    // public string SectorDisp { get; set; }
    // public string SectorKey { get; set; }
    // public int? ShareHolderRightsRisk { get; set; }
    // public long? SharesOutstanding { get; set; }
    // public string ShortName { get; set; }
    // public string State { get; set; }
    public string Symbol { get; set; }
    // public double? TargetHighPrice { get; set; }
    // public double? TargetLowPrice { get; set; }
    // public double? TargetMeanPrice { get; set; }
    // public double? TargetMedianPrice { get; set; }
    // public string TimeZoneFullName { get; set; }
    // public string TimeZoneShortName { get; set; }
    // public long? TotalCash { get; set; }
    // public double? TotalCashPerShare { get; set; }
    // public long? TotalDebt { get; set; }
    // public long? TotalRevenue { get; set; }
    // public double? TrailingEps { get; set; }
    // public double? TrailingPE { get; set; }
    // public double? TwoHundredDayAverage { get; set; }
    // public string UnderlyingSymbol { get; set; }
    // public string Uuid { get; set; }
    // public string Website { get; set; }
    // public string Zip { get; set; }    
    public int NumeroAcoes { get; set; }
    public int NumeroAcoesVendidas { get; set; }
    public double VlrDivYieldMes { get; set; }
    public double VlrDivYieldAno { get; set; }
    public double VariacaoValue { get; set; }
    public double VariacaoPercentual { get; set; }
    public DateTime DataUltCotacao { get; set; }
    public bool loading { get; set; } = false;
}
