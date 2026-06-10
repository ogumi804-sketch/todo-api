public class TodoItem
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// タイトル
    /// </summary>
    public string Title { get; set; } = "";
    
    /// <summary>
    /// 完了状態
    /// </summary>
    public bool IsCompleted { get; set; }
}