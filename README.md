[![Github Latest Release](https://img.shields.io/github/v/release/chillguy-leo/MusicWarhead)]() 
[![Github All Releases](https://img.shields.io/github/downloads/chillguy-leo/MusicWarhead/total.svg)]() 
# Apologies to all, I forgot to upload the required dependency
# MusicWarhead
Plays a desired audio file when the Warhead starts, I made this for [plugin request](https://discord.com/channels/656673194693885975/656709490959450113/1341844335049707600) in the Exiled Discord and I also wanted to learn how to use Git.

## Installation
- Install like any other plugin and place in */EXILED/Plugins \ 
- Add AudioPlayerApi to */EXILED/Plugins/dependencies \
- Restart server \
- Place audio somewhere you trust, maybe like */EXILED/Configs, then get the direct file address and put the address in 'audio_location' in settings

## Audio Setup
I would recomend [this](https://audio.online-convert.com/convert/mp3-to-ogg) to convert your mp3 files to ogg and set the correct preferences \
Set your channel to Mono & set the frequency to 48Khz so SCPSL can understand the audio correctly, then place your audio in a suitable location and place the direct address to it in `audio_location`

## Configs
Config.yml:
```yaml
music_warhead:
  # Is the plugin enabled?
  is_enabled: true
  # Where is the audio?
  audio_location: ''
  # How loud is the audio?
  audio_volume: 1.10000002
  # Should the audio stop after it ends or keep looping?
  stop_after_end: true
  # Should debug messages be displayed?
  debug: false
```

