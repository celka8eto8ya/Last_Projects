   M S B A M L   `   `   `  ����  NAudioWpfDemoG    ANAudioWpfDemo.MediaFoundationResample.MediaFoundationResampleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   6,   �� 5      $��* �6   6*   .+�5   
   �� $��5q�6   $����For testing the MediaFoundationResampler class. Select any file that Media Foundation can play, and then click Resample to create a WAV file at the desired sample rate. The Media Foundation Resampler also supports changing bit depth and channel count.��6   $
��Wrap=�6"  $	��Top=�66  �� 5   
   $��1��6   $��Input File:��6   $
��Left=�63   $��	10,10,0,0q�6N   $	��Top=�6a   �� 5   
   $��1��6   $��23��6   $��137,10.12,43,0q�6+    �� TextWrapping$
 Wrap=�6C   $	��Top=�6r    �� 
IsReadOnly . ��6W   �� *	InputFile+6�   �� 5   
   $��1��6   $	��...��6   $��	0,10,10,0q�6W   $	��Top=�6j   $��Right=�6�   $��28��6�   ��6,   �� *SelectInputFileCommand+6�   �� 5   
   $��1��6   $��Output Sample Rate:��6   $
��Left=�6;   $��10,72.12,0,0q�6V   $	��Top=�6l   �� 5   
   $��1��6   $
��Left=�6u   $��137,72.12,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6    �� *SampleRates+ �� SelectedItem 6D   �� *
SampleRate+ �� Mode$ TwoWay=�6�   �� 5   
   $��1��6   $��Resample��6   $
��Left=�6U   $��10,165.12,0,0q�6p   $	��Top=�6�   $��75��6�   ��61   �� *ResampleCommand+6�   �� 5   
   $��1��6   $��Input File Format:��6   $
��Left=�6:   $��10,41.12,0,0q�6U   $	��Top=�6k   �� 5   
   $��1��6   $
��Left=�6A   $��118,41.12,0,0q�6\   $	��Top=�6s   ��6   �� *InputFileFormat+6s   �� 5   
   $��
Bit Depth:��6   $
��Left=�6%   $��10,103.12,0,0q�6@   $��1��6W   $	��Top=�6d   �� 5   
   $
��Left=�6r   $��137,103.12,0,0q�6�   $��1��6�   $	��Top=�6�   $	��120��6�   ��6   �� *	BitDepths+ �� SelectedIndex 65   �� *SelectedBitDepthIndex+$ TwoWay=�6�   �� 5   
   $��Channel Count:��6   $
��Left=�6)   $��10,134.12,0,0q�6D   $��1��6[   $	��Top=�6h   �� 5   
   $
��Left=�6z   $��137,134.12,0,0q�6�   $��1��6�   $	��Top=�6�   $	��120��6�   ��6   �� *ChannelCounts+ 69   �� *SelectedChannelCountIndex+$ TwoWay=�6�   �� 5   
   $��Reposition Test��6   $
��Left=�6U   $��10,210.12,0,0q�6p   $��1��6�   $	��Top=�6�   $	��103��6�   ��6+   �� *RepositionTestCommand+6�   5      5      