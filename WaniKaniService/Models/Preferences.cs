﻿using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class Preferences
{
    [JsonPropertyName("default_voice_actor_id")]
    public int DefaultVoiceActorId { get; set; }

    [JsonPropertyName("lessons_autoplay_audio")]
    public bool LessonsAutoplayAudio { get; set; }

    [JsonPropertyName("lessons_batch_size")]
    public int LessonsBatchSize { get; set; }

    [JsonPropertyName("lessons_presentation_order")]
    public string LessonsPresentationOrder { get; set; } = null!;

    [JsonPropertyName("reviews_autoplay_audio")]
    public bool ReviewsAutoplayAudio { get; set; }

    [JsonPropertyName("reviews_display_srs_indicator")]
    public bool ReviewsDisplaySrsIndicator { get; set; }
}
