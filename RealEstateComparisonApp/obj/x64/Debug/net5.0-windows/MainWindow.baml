   M S B A M L   `   `   `  ����  RealEstateComparisonApp(    "RealEstateComparisonApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  Real Estate Price Comparison��5   	   $	��800��6.   $	��600��6:   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Select Dataset:��6   $��16(�6.   $��Center=�6<   �� 5      -   5         ��Name$ 
txtDataset��5      $��16(�6*   $	��400��68    �� 
IsReadOnly$
 True��6D   $��Center=�6V   $
��10,0q�6q   �� 5      -   5         ��Name$ btnPickDataset��5      $��Browse��6-   $��16(�6>   $��Center=�6c   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Year:��6   $��16(�6$   $��Center=�62   �� 5      -   5         ��Name$ cboYear��5      $��16(�6(   $	��100��66   $��Center=�6B   $
��10,0q�6]   �� 5      -   5        $ 
btnCompare��5      $��Compare��6)   $��16(�6;   $��Center=�6\   $
��10,0q�6w   $	��101��6�   5      (  "System.Windows.Controls.WebBrowser  5   
   -   5          Name$ myWebBrowser��5      $��2��6+   5      5      