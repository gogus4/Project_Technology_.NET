   M S B A M L   `   `   `  ����G  CWpfScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:WpfScheduler;assembly=WpfSchedulerWpfScheduler  5   	    Carmotub&    Carmotub.Views.Controls.Calendar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ?my0clr-namespace:WpfScheduler;assembly=WpfScheduler     5   	   -   5        .��5      �   � RowDefinitions  5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��20,0,0,0q�6;   .+�5      �� -   5         ��Name$ RemoveMonth��5      $��20(�6*   
������ 
������ $��32��6k   $��32��6w   ��5      �� 5      $/��)/Carmotub;component/Assets/arrow_left.png��6   5      �� 5      -   5        $ AddMonth��5      $��20(�6'   
������ 
������ $��32��6h   $��32��6t   ��5      �� 5      $0��*/Carmotub;component/Assets/arrow_right.png��6   5      �� 5      -   5         ��Name$ CurrentMonthAndYear��5      $��20(�65   $��Segoe UI)�6C   $��5,0,0,0q�6Y   $��Center=�6j   �� 5      -   5        $ RefreshCalendar��5      $��20(�6.   
������ 
������ $��5,0,0,0q�6o   $��32��6�   $��32��6�   ��5      �� 5      $,��&/Carmotub;component/Assets/refresh.png��6   5      5          WpfScheduler.Scheduler  5"   
   -   5        $��
scheduler1��5$   +   $��1��5#      $��Stretch=�5$      $��Stretch=�6=      StartJourney$ 00:00h�5%         
EndJourney$ 23:59h�5&         Mode$ Month=�5)      5*      5+      5,      