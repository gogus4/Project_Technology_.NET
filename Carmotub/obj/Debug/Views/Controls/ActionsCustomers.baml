   M S B A M L   `   `   `  ����  Carmotub.    (Carmotub.Views.Controls.ActionsCustomers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      �   � RowDefinitions  5   
   �� 5	      $��34 �6   �� 5
      $��* �6   .+�5   
   �� $��Right=�6   $��Center=�61   $��0��6L   $��0,0,10,0q�6Y   .+�5      �� $��12(�6   $��Segoe UI Light)�6&   �� 5      $�Nombre de clients : ��6    �� 5      -   5         ��Name$ NumberCustomers��5      5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��5q�6;   .+�5      �� $��Rechercher par :��6   $��Center=�60   $��12(�6K   $��Segoe UI Light)�6Y   �� 5      -   5         ��Name$ SearchBy��5      $��5,0,0,0q�6)   $��Center=�6:   $��20��6U    �� SelectedIndex$ 0��6a   $	��160��6s   
�������$��12(�6�   $��Segoe UI Light)�6�   .@�5      �� .��6   Nom6$   5      �� 5      -   5         ��Name$ SearchBorder��5      $��10,0,0,0q�6+   $��20��6=   
�������$y�Visible=�6a   $��1q�6v   
�������._�5      �� $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ SearchBoxText��5      $	��200��65   
������ $��0q�6[   �� 5      -   5         ��Name$ SearchButton��5      
������ 
������ ��5      �� 5       $+��%/Carmotub;component/Assets/search.png��6$   5"      5#      5$      5%      � 5'   
   $��1��6   .+�5(      � -   5         �Name$ ProgressBackupDatabase��5(      $y�	Collapsed=�6:   	 � Maximum$		 128Q�6Q   &   System.Windows.Controls.DataGrid  5*      -   5        
  Name$
 DataGridCustomers��5*         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 62   $��Segoe UI Light)�6B   
�������   
IsReadOnly .    AutoGenerateColumns .  $��Stretch=�6�      CanUserDeleteRows .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����53      54      55      56      