   M S B A M L   `   `   `  ����Q  MQS PillsController Pro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:QS_PillsController_ProQS_PillsController_Pro  5   	   '    !QS_PillsController_Pro.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Fav9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   4local$clr-namespace:QS_PillsController_Pro    5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ QS PillsController PRO��5   	   $	��470��6(   $	��820��65   $��Center=�6A   $��Center=�6^    � 
ResizeMode$ NoResize=�6y    � Icon$ Resources/pills.png��6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5"   
   �� -   5         ��Name$ 	PillImage��5"   2   $��0��6   $��3��6   $��Center=�6E   $	��100��6b   $��Center=�6o   $	��100��6�   $��/Resources/pills.png��6�   �� 5#   
   -   5         ��Name$ NameTBox��5#   -   $��0��6   $��1��6    $��Type your medicine name:��6?   $��Right=�6b   	 � Cursor$	 Arrow��6~   $��20(�6�   $��37��6�   $��Segoe UI Semibold)�6�   �� 5$   
   -   5        
 ��Name$
 NameBox��5$   �   $��1��6~   $��1��6�   $
��Left=�6�   $��33��6�   $��Stretch=�6�   $��20(�6�   $	��400��6�   $��2��6	  ��6   �� *
PillName+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ local:MainWindowL�6	  �� 5%   
   -   5        $ FrequencyTBox��5%   -   $��0��6   $��2��6    $.��(Choose frequency of consumption per day:��6D   $��Right=�6w   $��Stretch=�6�   $	��397��6�   $	 Arrow��6�   $��20(�6�   $��37��6�   $��Segoe UI Semibold)�6  $��2��6*  $��0,12,198.2,11q�6A  �� 5&   
   -   5         ��Name$ FrequencyBox��5&   �   $��2��6�   $��1��6�   $��37��6�   $��20(�6�    �� Text 6   �� *	Frequency+ �� $ FindAncestor=�$ local:MainWindowL�.@�5'      ��  �� 
IsSelected . $��1��5(   '   �� 5)      $��2��6   �� 5*      $��3��6   5+      (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ StartDatePicker��5-         SelectedDateFormat$ Short=�5,   g   $��1��6�   $��3��6�   $��20(�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Start Date��5.      -  'MaterialDesignThemes.Wpf.CalendarAssist   IsHeaderVisible . $��37��50         Text 5,      �� *StartDateTime+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�51      �� 52   
   -   5        $ StartDatePickerTBox��52   -   $��0��6   $��3��6    $'��!Choose start date of consumption:��6J   $��20(�6v   $��Right=�6�   $��Stretch=�6�   $��37��6�   $��Segoe UI Semibold)�6�     53   
   -   5        $ EndDatePicker��54      $ Short=�53   �   $��4��6�   $��1��6�   $ End Date��55       . $��37��56   J   $��20(�6V    53   C   �� *EndDateTime+$ PropertyChanged=�$ TwoWay=�57      �� 58   
   -	   5        $ EndDatePickerTBox��58   -   $��4��6   $��0��6   $%��Choose end date of consumption:��6H   $	��313��6r   $	 Arrow��6~   $��20(�6�   $��37��6�   $��Right=�6�   $��Stretch=�6�   $��Segoe UI Semibold)�6�   �� 59   
   -
   5        $��2��59      $��5��6%    # MaterialDesignFlatLightBgButton#��[ 5:       � ToolTip$# MaterialDesignFlatLightButton��5;      $��299,14,100.2,14q�5=      $��20(�6*   {�59   2   �� *
isEnabled1+.��5=   8   Okay5?      )  #MaterialDesignThemes.Wpf.TimePicker  5@   
   -   5          Name$ PresetTimePicker1��5B   $   $��2��5@   �   $��2��6�   $��Center=�6�   $��Stretch=�6  $��37��6+     	Is24Hours . $	��117��5C   $   {�5@   $   �� *
isEnabled1+$ PropertyChanged=�   Text 6l   �� *Time1+ �� $ FindAncestor=�$ local:MainWindowL�5C   $     5D   
   -   5        $ PresetTimePicker2��5G   $   $��2��5D   �   $��3��6�   $��Center=�6�   $��Stretch=�6  $��37��6*   . $	��117��5H   $   {�5D   $   �� *
isEnabled2+$ PropertyChanged=� 6k   �� *Time2+ �� $ FindAncestor=�$ local:MainWindowL�5H   $     5I   
   -   5        $ PresetTimePicker3��5K   $   $��2��5I   �   $��4��6�   $��Center=�6�   $��Stretch=�6  $��37��6*   . $	��117��5K   @   {�5I   $   �� *
isEnabled3+$ PropertyChanged=� 6k   �� *Time3+ �� $ FindAncestor=�$ local:MainWindowL�5K   @   �� 5M   
   -   5        $ HistoryButton��5M      $��2��6'   $��Right=�67   $��50��6S   $	��Top=�6_   $��50��6w   $��/Resources/calendar.png��6�   $��0,24,23.6,0q�6�   �� 5N   
   $��2��6   $��Segoe UI Semibold)�6!   $��HISTORY��6@   $��120.8,74,1.6,23q�6R   $��Center=�6k   $��Center=�6�   $��76��6�   $
��Bold"�6�   5O      5P      