   M S B A M L   `   `   `  ����  Carmotub#    Carmotub.Views.UpdateCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Modifier un client��5   	   $
��Auto��6$    � SizeToContent$ Height=�62   $	��580��6I    � 
ResizeMode$ NoResize=�6U    � WindowStartupLocation$ CenterScreen=�6k   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $	��200 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��0.22* �6   �� 5      $
��0.3* �6   �� 5      $��0.22* �6   �� 5      $
��0.3* �6   .+�5   
   �� $��4��6   $��5,0,0,0q�6(   $��26(�69   $��Segoe UI Light)�6G   �� 5      $�Modifier le client��6    �� 5      $
��Bold"�68   �6   �� *CustomerToUpdate.nom+68    �� 5      $� ��6   $
��Bold"�6    �� 5      $
��Bold"�6;   �6   �� *CustomerToUpdate.prenom+6;   5      � 5   
   -   5         �Name$ 
ListPhotos��5      $��1��6   $	��175��60   $y�Visible=�6=   $��4��6R   $��5,0,5,0q�6f    5      �� 5      $��0.12* �6    �� 5       $��* �6    .+�5#      �� $��Liste des photos : ��6   $��Segoe UI Light)�63   $��0��6O   $��0��6\   $��5,0,0,0q�6l   �� 5%      -   5         ��Name$ ImageListbox��5%      $��1��6,   $��Visible=�5&   	   $��0,5,0,0q�6>   ��5(      �� 5)      .R�5*      �� $��2q�6!   
���   �._�5+      �� $	��120��6;   $	��120��6H   $	��Top=�6T   $
��Fill=�6l   ��6$   �� *uri+6l   5,      5-      ��50      �� 51      .R�52      � 53      55      56      � 58   
   -   5        $ UpdateCustomerGridRow��58      $��2��6.   $��4��6;    59      �� 5:      $��0.22* �6#   �� 5;      $
��0.3* �6#   �� 5<      $��0.22* �6#   �� 5=      $
��0.3* �6#   5?      �� 5A   
   $ ��Liste des interventions : ��6   $��Segoe UI Light)�66   $��3��6R   $��4��6_   $��5,0,0,0q�6s   &   System.Windows.Controls.DataGrid  5C   
   -   5          Name$ DataGridInterventions��5C      	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 62   $��4��6B   $��4��6O   $��5,0,5,0q�6c   $��Segoe UI Light)�6t   
�������
   
IsReadOnly
 .    AutoGenerateColumns .  $��Stretch=�6�      CanUserDeleteRows .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����6Q  �� 5E   
    �� Orientation$ 
Horizontal=�6   $��5,5,0,5q�6.   $��5��6?   $��4��6L   .+�5F      �� -   5         ��Name$ UpdateCustomerButton��5F      $��Modifier le client��64   $��Segoe UI Light)�6Q   $��12(�6m   $	��120��6{   $��20��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5G      -   5        $ AddPhoto��5G      $��Ajouter une photo��6(   $��Segoe UI Light)�6D   $��5,0,0,0q�6`   $��12(�6q   $	��120��6   $��20��6�   $
��Left=�6�   $	��Top=�6�   6�   5H      5I      5J      