   M S B A M L   `   `   `  ����  Carmotub    Carmotub.Views.UpdateUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AddUser��5   	   $	��640��6   $	��580��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5	      $
��Auto �6   �� 5
      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5 �6   �� 5      $	��200 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��0.22* �6   �� 5       $
��0.3* �6   �� 5!      $��0.22* �6   �� 5"      $
��0.3* �6   .+�5%   
   �� $��4��6   $��5,0,0,0q�6(   $��26(�69   $��Segoe UI Light)�6G   �� 5&      $�Modifier le client��6    �� 5'      $
��Bold"�68   �6   �� *CustomerToUpdate.nom+68    �� 5(      $� ��6   $
��Bold"�6    �� 5)      $
��Bold"�6;   �6   �� *CustomerToUpdate.prenom+6;   5*      �� 5,   
   $��Nom : ��6   $��Segoe UI Light)�6"   $��2��6>   $��0��6K   $��5,0,0,0q�6[   �� 5-   
   -   5         ��Name$
 Name��5-      $
��Left=�6F   $��Segoe UI Light)�6a   $	��140��6}   $��2��6�   $��1��6�   ��6    �� *CustomerToUpdate.nom+6�   �� 5/   
   $��Escalier : ��6   $��Segoe UI Light)�6'   $��2��6C   $��2��6P   $��5,0,0,0q�6`   �� 50   
   -   5        $ Escalier��50      $
��Left=�6O   $��Segoe UI Light)�6j   $	��140��6�   $��2��6�   $��3��6�   ��6$   �� *CustomerToUpdate.escalier+6�   �� 52   
   $��
Prénom : ��6   $��Segoe UI Light)�6%   $��4��6A   $��0��6N   $��5,0,0,0q�6^   �� 53   
   -   5        $ 	Firstname��53      $
��Left=�6N   $��Segoe UI Light)�6i   $	��140��6�   $��4��6�   $��1��6�   ��6%   �� *CustomerToUpdate.prenom+6�   �� 55   
   $��Telephone fixe : ��6   $��Segoe UI Light)�6-   $��4��6I   $��2��6V   $��5,0,0,0q�6f   �� 56   
   -   5        $ TelFixe��56      $
��Left=�6Q   $��Segoe UI Light)�6l   $	��140��6�   $��4��6�   $��3��6�   ��6#   �� *CustomerToUpdate.telephone_1+6�   �� 58   
   $��
Adresse : ��6   $��Segoe UI Light)�6&   $��6��6B   $��0��6O   $��5,0,0,0q�6_   �� 59   
   -   5        $ Adresse��59      $
��Left=�6M   $��Segoe UI Light)�6h   $	��140��6�   $��6��6�   $��1��6�   ��6#   �� *CustomerToUpdate.adresse+6�   �� 5;   
   $��Telephone port : ��6   $��Segoe UI Light)�6-   $��6��6I   $��2��6V   $��5,0,0,0q�6f   �� 5<   
   -   5        $ TelPortable��5<      $
��Left=�6U   $��Segoe UI Light)�6p   $	��140��6�   $��6��6�   $��3��6�   ��6'   �� *CustomerToUpdate.telephone_2+6�   �� 5>   
   $��Code postal : ��6   $��Segoe UI Light)�6*   $��8��6F   $��0��6S   $��5,0,0,0q�6c   �� 5?   
   -   5        $ 
CodePostal��5?      $
��Left=�6T   $��Segoe UI Light)�6o   $	��140��6�   $��8��6�   $��1��6�   ��6&   �� *CustomerToUpdate.code_postal+6�   �� 5A   
   $��Code : ��6   $��Segoe UI Light)�6#   $��8��6?   $��2��6L   $��5,0,0,0q�6\   �� 5B   
   -   5        $
 Code��5B      $
��Left=�6G   $��Segoe UI Light)�6b   $	��140��6~   $��8��6�   $��3��6�   ��6    �� *CustomerToUpdate.code+6�   �� 5D   
   $��Ville : ��6   $��Segoe UI Light)�6$   $��10��6@   $��0��6N   $��5,0,0,0q�6^   �� 5E   
   -	   5        $ Ville��5E      $
��Left=�6I   $��Segoe UI Light)�6d   $	��140��6�   $��10��6�   $��1��6�   ��6!   �� *CustomerToUpdate.ville+6�   �� 5G   
   $��Rendez-vous : ��6   $��Segoe UI Light)�6*   $��10��6F   $��2��6T   $��5,0,0,0q�6d   �� 5H   
   -
   5        $	 Rdv��5H      $
��Left=�6E   $��Segoe UI Light)�6`   $	��140��6|   $��10��6�   $��3��6�   ��6   �� *CustomerToUpdate.Rdv+6�   �� 5J   
   $��Etage : ��6   $��Segoe UI Light)�6$   $��12��6@   $��0��6N   $��5,0,0,0q�6^   �� 5K   
   -   5        $ Etage��5K      $
��Left=�6I   $��Segoe UI Light)�6d   $	��140��6�   $��12��6�   $��1��6�   ��6!   �� *CustomerToUpdate.etage+6�   �� 5M   
   $��Recommandé par : ��6   $��Segoe UI Light)�6-   $��12��6I   $��2��6W   $��5,0,0,0q�6g   �� 5N   
   -   5        $ RecommandePar��5N      $
��Left=�6Z   $��Segoe UI Light)�6u   $	��140��6�   $��12��6�   $��3��6�   ��6)   �� *!CustomerToUpdate.recommande_par+6�   �� 5P   
   $��Commentaire : ��6   $��Segoe UI Light)�6*   $��14��6F   $��4��6T   $��5,2,0,0q�6h   �� 5R   
    �� Orientation$ Vertical=�6   $��16��6,   $��4��6:   $��5,0,5,0q�6N   .+�5S      �� -   5         ��Name$ Commentaire��5S      $��Visible=�6/   $��Segoe UI Light)�6b   $	��110��6~   5T      �� 5V   
   $ ��Liste des interventions : ��6   $��Segoe UI Light)�66   $��17��6R   $��4��6`   $��5,0,0,0q�6t   &   System.Windows.Controls.DataGrid  5X   
   -   5          Name$ DataGridInterventions��5X      $��19��6X   $��4��6f   $��5,0,5,0q�6z   $��Segoe UI Light)�6�   
�������	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $��Stretch=�6�      CanUserDeleteRows .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �������62   �� *Interventions+   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *date+  5[      $ Type de chaudière��6%    6@   �� *type_chaudiere+  5\      $ Carnet��6%    65   �� *carnet+  5]      $ Nature��6%    65   �� *nature+  5^      $ Montant��6%    66   �� *	montant+5`      �� 5b   
   -   5         ��Name$ UpdateCustomer��5b      $��20��6)   $��4��67   $��Modifier le client��6K   $��Segoe UI Light)�6h   $��12(�6�   $	��120��6�   $��20��6�   $
��Left=�6�   $	��Top=�6�   $��5,5,0,0q�6�   6�   5d      5e      