# How to change the individual appearance of the WPF Bar Chart (SfChart)?

This article describes how to change the individual appearance(color) of bar segment based on the corresponding YValues in WPF SfChart by following these steps:

**Step 1:** To change color for specific data point in chart you can refer this [KB article](https://www.syncfusion.com/kb/10928/how-to-change-colors-of-specific-data-points-in-the-chart).

**Step 2:** Also you can customize the interior color of the particular segment based on the respective Y value by using the converter in the [CustomTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ColumnSeries.html#Syncfusion_UI_Xaml_Charts_ColumnSeries_CustomTemplate) property of [ColumnSeries](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ColumnSeries.html) as demonstrated in the following code example. The detailed explanation of this appearance customization can be found in this user documentation [page](https://help.syncfusion.com/wpf/charts/seriestypes/custom).

**[XAML]**
```
<Grid>
        <Grid.DataContext>
            <local:ViewModel/>
        </Grid.DataContext>

        <Grid.Resources>
            <local:InteriorConverter x:Key="interiorConverter"/>
        </Grid.Resources>

        <chart:SfChart Margin="10">

            <chart:SfChart.PrimaryAxis>
                <chart:CategoryAxis LabelFormat="yyyy"></chart:CategoryAxis>
            </chart:SfChart.PrimaryAxis>

            <chart:SfChart.SecondaryAxis>
                <chart:NumericalAxis></chart:NumericalAxis>
            </chart:SfChart.SecondaryAxis>

            <chart:ColumnSeries XBindingPath="Year" YBindingPath="India" ItemsSource="{Binding DataPoints}">
                <chart:ColumnSeries.CustomTemplate>
                    <DataTemplate>
                        <Canvas>
                            <Rectangle Fill="{Binding Converter={StaticResource interiorConverter}}" Height="{Binding Height}" Width="{Binding Width}" Canvas.Left="{Binding RectX}" Canvas.Top="{Binding RectY}"></Rectangle>
                        </Canvas>
                    </DataTemplate>
                </chart:ColumnSeries.CustomTemplate>
                <chart:ColumnSeries.AdornmentsInfo>
                    <chart:ChartAdornmentInfo AdornmentsPosition="TopAndBottom" LabelPosition="Center" SegmentLabelContent="LabelContentPath" ShowLabel="True" >
                        <chart:ChartAdornmentInfo.LabelTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <Label Content="{Binding Item.India}" Foreground="White" FontSize="11"></Label>
                                </StackPanel>
                            </DataTemplate>
                        </chart:ChartAdornmentInfo.LabelTemplate>
                    </chart:ChartAdornmentInfo>
                </chart:ColumnSeries.AdornmentsInfo>
            </chart:ColumnSeries>

        </chart:SfChart>
</Grid>
```
    
**[C#]**
```
public class InteriorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var ydata = (value as ColumnSegment).YData;
        Brush interior;

        interior = ydata > 0 ?
            new SolidColorBrush(Colors.Green) :
            new SolidColorBrush(Colors.Red);

        return interior;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

**View Model**
```
public class ViewModel
{
    public ViewModel()
    {
        this.DataPoints = new ObservableCollection<Model>();
        DateTime year = new DateTime(2005, 5, 1);

        DataPoints.Add(new Model() { Year = year.AddYears(1), India = 28, Germany = 31, England = 36, France = 39 });
        DataPoints.Add(new Model() { Year = year.AddYears(2), India = 25, Germany = 28, England = 32, France = 36 });
        DataPoints.Add(new Model() { Year = year.AddYears(3), India = 26, Germany = 30, England = 34, France = 40 });
        DataPoints.Add(new Model() { Year = year.AddYears(4), India = -27, Germany = 36, England = 41, France = 44 });
        DataPoints.Add(new Model() { Year = year.AddYears(5), India = -32, Germany = 36, England = 42, France = 45 });
        DataPoints.Add(new Model() { Year = year.AddYears(6), India = 35, Germany = 39, England = 42, France = 48 });
        DataPoints.Add(new Model() { Year = year.AddYears(7), India = -30, Germany = 38, England = 43, France = 46 });
    }

    public ObservableCollection<Model> DataPoints { get; set; }
}

public class Model
{
    public DateTime Year { get; set; }
    public double India { get; set; }
    public double Germany { get; set; }
    public double England { get; set; }
    public double France { get; set; }
}
```

## Output:

![Customized color for individual bar segment](https://user-images.githubusercontent.com/102642528/208101109-2bca6919-469c-40e5-9272-2919fb6014a1.jpg)

## See also:

[Series customization in WPF SfChart](https://help.syncfusion.com/wpf/charts/seriescustomization)

[How-to-customize-the-chart-series-in-WPF-SfChart?](https://github.com/SyncfusionExamples/how-to-customize-the-chart-series-in-wpf-sfchart)
