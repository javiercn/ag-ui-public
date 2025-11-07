using System.Text.Json.Serialization;

namespace AGUIDojoServer;

internal sealed class TaskPlan
{
    [JsonPropertyName("steps")]
    public List<TaskPlanStep> Steps { get; set; } = [];
}

internal sealed class TaskPlanStep
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;
}

internal sealed class UiComponentResponse
{
    [JsonPropertyName("component")]
    public UiComponent Component { get; set; } = new();
}

internal sealed class UiComponent
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("fields")]
    public List<UiField> Fields { get; set; } = [];
}

internal sealed class UiField
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;

    [JsonPropertyName("control")]
    public string Control { get; set; } = "text";

    [JsonPropertyName("options")]
    public List<string>? Options { get; set; }
}

internal sealed class RecipeState
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("ingredients")]
    public List<string> Ingredients { get; set; } = [];

    [JsonPropertyName("steps")]
    public List<string> Steps { get; set; } = [];
}

internal sealed class DraftDocument
{
    [JsonPropertyName("sections")]
    public List<DraftSection> Sections { get; set; } = [];
}

internal sealed class DraftSection
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}
