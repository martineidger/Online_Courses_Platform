using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public User User {  get; set; }
        public string CommentText {  get; set; }
        public bool HasReplies { get; set; } = false;
        public ObservableCollection<Comment>? Replies { get; set; } = new ObservableCollection<Comment>();
    }
}
