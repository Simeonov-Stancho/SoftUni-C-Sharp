class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        }

        if (username == this.creator) {
            throw new Error("You can't like your own story!");
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        }

        for (let i = 0; i < this._likes.length; i++) {

            if (this._likes[i] === username) {

                this._likes.splice(i, 1);
            }

        }

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let comment = {
            id: this._comments.length + 1,
            username: username,
            content: content,
            replies: [],
        }

        if (id == undefined || id > this._comments.length || id < 0) {
            this._comments.push(comment);
            return `${username} commented on ${this.title}`;
        } else {
            let currentComment = this._comments.find(c => c.id == id);
            let replay = {
                id: currentComment.replies.length + 1,
                username: username,
                content:content,
            }
            
            currentComment.replies.push(replay);

            return "You replied successfully";
        }
    }

    toString(sortingType) {
        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push(`Comments:`);

        if (this._comments.length != 0) {

            if (sortingType == 'asc') {
                this._comments.sort((a, b) => a.id - b.id);
                this._comments.forEach(c => {
                    if (c.replies.length != 0) {
                        c.replies.sort((a, b) => a.id - b.id);
                    }
                });

            } else if (sortingType == `desc`) {
                this._comments.sort((a, b) => b.id - a.id);
                this._comments.forEach(c => {
                    if (c.replies.length != 0) {
                        c.replies.sort((a, b) => b.id - a.id);
                    }
                });

            } else if (sortingType == `username`) {
                this._comments.sort((a, b) => a.username.localeCompare(b.username));
                this._comments.forEach(c => {
                    if (c.replies.length != 0) {
                        c.replies.sort((a, b) => a.username.localeCompare(b.username));
                    }
                });
            }

            this._comments.forEach(c => {
                result.push(`-- ${c.id}. ${c.username}: ${c.content}`);
            });

            this._comments.forEach(c => {

                if (c.replies.length != 0) {
                    c.replies.forEach(r => {
                        result.push(`--- ${c.id}.${r.id}. ${r.username}: ${r.content}`);
                    });
                }
            });
        }

        return result.join('\n')
    }

    
//     toString(sortingType){
//         let output = '';
//         output += `Title: ${this.title}\n`;
//         output += `Creator: ${this.creator}\n`;
//         output += `Likes: ${this._likes.length}\n`;
//         output += 'Comments:';

//         if (this._comments.length > 0){
//             if (sortingType === 'asc'){
//                 for (const comment of this._comments.sort((a,b) => a.id - b.id)) {
//                     output += `\n-- ${comment.id}. ${comment.username}: ${comment.content}`;
//                     for (const reply of comment.replies.sort((a,b) => a.id - b.id)) {
//                         output += `\n--- ${comment.id}.${reply.id}. ${reply.username}: ${reply.content}`;
//                     }
//                 }
//             } else if (sortingType === 'desc'){
//                 for (const comment of this._comments.sort((a,b) => b.id - a.id)) {
//                     output += `\n-- ${comment.id}. ${comment.username}: ${comment.content}`;
//                     for (const reply of comment.replies.sort((a,b) => b.id - a.id)) {
//                         output += `\n--- ${comment.id}.${reply.id}. ${reply.username}: ${reply.content}`;
//                     }
//                 }
//             } else if (sortingType === 'username'){
//                 for (const comment of this._comments.sort((a,b) => a.username.localeCompare(b.username))) {
//                     output += `\n-- ${comment.id}. ${comment.username}: ${comment.content}`;
//                     for (const reply of comment.replies.sort((a,b) => a.username.localeCompare(b.username))) {
//                         output += `\n--- ${comment.id}.${reply.id}. ${reply.username}: ${reply.content}`;
//                     }
//                 }
//             }
//         }
//         return output;
//     }
}


let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('asc'));
