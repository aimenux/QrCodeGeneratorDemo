﻿using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;

namespace Benchs;

public class BenchConfig : ManualConfig
{
    public BenchConfig()
    {
        HideColumns(Column.RatioSD);
        AddColumn(RankColumn.Arabic);
        AddColumn(StatisticColumn.Min);
        AddColumn(StatisticColumn.Max);
        AddColumn(CategoriesColumn.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
        AddLogger(ConsoleLogger.Default);
        AddExporter(RPlotExporter.Default);
        AddExporter(CsvMeasurementsExporter.Default);
        AddExporter(HtmlExporter.Default);
        AddExporter(MarkdownExporter.GitHub);
        AddExporter(MarkdownExporter.Default);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddDiagnoser(ExceptionDiagnoser.Default);
        AddLogicalGroupRules(BenchmarkLogicalGroupRule.ByParams);
        WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest));
        WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend));
    }
}