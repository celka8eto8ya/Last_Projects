   M S B A M L   `   `   `  ����  NAudioWpfDemoG    ANAudioWpfDemo.MediaFoundationPlayback.MediaFoundationPlaybackView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $
��263* �6   .+�5   
   �� $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $q��kDemonstrates the use of the MediaFoundationReader for playback, repositioning. Currently a work in progress��6V   $	��Top=�6�   �� 5   
   $��1��6   $	��...��6   $��0,10.08,10,0q�6L   $	��Top=�6b   $��Right=�6z   $��34��6�   ��6,   �� *LoadCommand+6�   �� 5   
   $��1��6   $
��Play��6   $
��Left=�6M   $��11,73.08,0,0q�6h   $	��Top=�6~   $��75��6�   ��6-   �� *PlayCommand+6�   �� 5   
   $��1��6   $��Pause��6   $
��Left=�6O   $��91,73.08,0,0q�6j   $	��Top=�6�   $��75��6�   ��6.   �� *PauseCommand+6�   �� 5   
   $��1��6   $
��Stop��6   $
��Left=�6M   $��171,73.08,0,0q�6h   $	��Top=�6   $��75��6�   ��6-   �� *StopCommand+6�   �� 5   
   $��1��6   $'��!Default PCM decompression format:��6   $
��Left=�6I   $��11,34.08,0,0q�6d   $	��Top=�6z   �� 5   
   $��1��6   $
��Left=�6L   $��211,34.08,0,0q�6g   $	��Top=�6~   ��6   �� *DefaultDecompressionFormat+6~   �� 5   
   -   5        $��waveFormCanvas��5      $��1��6   
���   �$
��Left=�6G   $��48��6b   $��11,127.08,0,0q�6n   $	��Top=�6�   $	��480��6�   �� 5   
   $��1��6   $��11,100.08,19,0q�6   $	��Top=�66    � Value 6N   �� *SliderPosition+ �� Mode$ TwoWay=��� 5   
   $��1��6   $��Request IEEE Float��6@   $
��Left=�6�   $��367,76.08,0,0q�6�   $	��Top=�6�   {�6    �� *	IsStopped+ d� 	IsChecked 6]   �� *RequestFloatOutput+$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��11,11.08,0,0q�6/   $��1��6E   $
��Wrap=�6R   $��Selected File or URL:��6f   $	��Top=�6�   �� 5   
   $��126,10.08,49,0q�6d   $��1��6|   $	��Top=�6�    �� 
IsEditable .  �� Text 6   �� *	InputPath+$ TwoWay=���6;   �� *InputPathHistory+6�   5      5      