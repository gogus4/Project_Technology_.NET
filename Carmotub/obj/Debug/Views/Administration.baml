   M S B A M L   `   `   `  ����  Carmotub#    Carmotub.Views.Administration   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Administration��5   	   $	��300��6    $
��Auto��6,    � SizeToContent$ Height=�6:    � WindowStartupLocation$ CenterScreen=�6Q   .��5      � .+�5   
   �� -   5        $��
ListTables��5      .@�5      �� $��Client��6   .��5      ��  �� Orientation$ Vertical=�6   .+�5	      �� -   5         ��Name$ AddFieldCustomer��5	      $��Ajouter un champ��67   $��Segoe UI Light)�6R   $��Right=�6n   $��5,5,0,5q�6�   $��5q�6�   $��12(�6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ DataGridCustomerColumn��5      $��Segoe UI Light)�6?      
IsReadOnly .    AutoGenerateColumns .  $��Stretch=�6�      CanUserDeleteRows .  	   HorizontalGridLinesBrush
	 �����
   VerticalGridLinesBrush

 �����   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.8* 61      Header$ Nom de la colonne��6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Y   �� 4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 0.2* 65    �� TextAlignment$ Center=�6B   $ Actions��6c      CellTemplate 5   "   �� 5   &   .R�5   *   � $��Center=�6/   .+�5   .   �� $ DeleteCustomerColumn��65   -   5        
������ 
������ $��0q�5   �   
 � Tag 6S   �� .��5   2   �� $+��%/Carmotub;component/Assets/delete.png��68   $��16��6g   $��16��6r   5   /   5   +   5   '   5      5      5      5      �� 5      $��Intervention��6   .��5      �� $ Vertical=�6   .+�5       �� -   5        $ AddFieldIntervention��5       $��Ajouter un champ��6;   $��Segoe UI Light)�6V   $��Right=�6r   $��5,5,0,5q�6�   $��5q�6�   $��12(�6�   6�     5"      -   5        $  DataGridInterventionColumn��5"      $��Segoe UI Light)�6C   
������� .  .  $��Stretch=�6�    .  
	 �����

 ����� 5#        5$      $
 0.8* 61   $ Nom de la colonne��6>    6Y   ��   5%      $
 0.2* 65   $ Center=�6B   $ Actions��6c    5&   "   �� 5'   &   .R�5(   *   � $��Center=�6/   .+�5)   .   �� $ DeleteInterventionColumn��65   -   5        
������ 
������ $��0q�5)   �    6W   �� .��5*   2   �� $+��%/Carmotub;component/Assets/delete.png��68   $��16��6g   $��16��6r   5+   /   5,   +   5-   '   5/      51      52      53      54      55      56      