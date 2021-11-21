//Victor
function attachEvents() {
    const loadBtn = document.getElementById('btnLoadPosts');
    const viewBtn = document.getElementById('btnViewPost');

    loadBtn.addEventListener('click', loadPosts);
    viewBtn.addEventListener('click', displayPost);
}

attachEvents();

async function displayPost() {
    const ulEl = document.getElementById('post-comments');
    ulEl.innerHTML = '';

    const postId = document.getElementById('posts').value;
    const [post, comments] = await Promise.all
        ([getPostById(postId),
        viewComment(postId)])

    const postTitle = document.getElementById('post-title');
    const postBody = document.getElementById('post-body');
    postTitle.textContent = post.title;
    postBody.textContent = post.body;

    comments.forEach(c => {
        console.log(c)
        const lieEl = document.createElement('li');
        lieEl.textContent = c.text;
        ulEl.appendChild(lieEl);
    });
}

async function loadPosts() {
    let posts = document.getElementById('posts');
    posts.innerHTML = '';

    const postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
    const response = await fetch(postsUrl);

    try {
        if (response.status != 200) {
            throw new Error('Error postsUrl');
        }

        let data = await response.json();

        Object.values(data).forEach(p => {
            const optionEl = document.createElement('option');
            optionEl.value = p.id;
            optionEl.textContent = p.title;
            document.getElementById('posts').appendChild(optionEl);
        })

    } catch (error) {
        console.log(error);
    }
}

async function getPostById(postId) {
    const postUrl = `http://localhost:3030/jsonstore/blog/posts/${postId}`;

    const response = await fetch(postUrl);
    const data = await response.json();

    return data;
}

async function viewComment(postId) {
    const commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;
    let responseComments = await fetch(commentsUrl);
    try {
        if (responseComments.status != 200) {
            throw new Error('Error commentsUrl');
        }

        let data = await responseComments.json();
        const comment = Object.values(data).filter(c => c.postId == postId);

        return comment;
    } catch (error) {
        console.log(error);
    }
}

//Stancho
// function attachEvents() {
//     const loadBtn = document.getElementById('btnLoadPosts');
//     const viewBtn = document.getElementById('btnViewPost');

//     let posts = document.getElementById('posts');
//     let postsTitle = document.getElementById('post-title');
//     let postsBody = document.getElementById('post-body');

//     let comments = document.getElementById('post-comments');

//     const postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
//     const commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;

//     loadBtn.addEventListener('click', loadPosts);
//     viewBtn.addEventListener('click', viewPost);

//     async function loadPosts() {
//         posts.innerHTML = '';

//         let response = await fetch(postsUrl);

//         try {
//             if (response.status != 200) {
//                 throw new Error('Error postsUrl');
//             }

//             let data = await response.json();

//             Object.entries(data).forEach(post => {
//                 let optionEl = document.createElement('option');
//                 optionEl.value = post[0];
//                 optionEl.textContent = post[1].title;
//                 posts.appendChild(optionEl);
//             })

//         } catch (error) {
//             console.log(error);
//         }
//     }

//     async function viewPost() {
//         comments.innerHTML = '';
//         let responsePost = await fetch(`http://localhost:3030/jsonstore/blog/posts/${posts.value}`);
//         let dataPost = await responsePost.json();

//         postsTitle.textContent = dataPost.title;
//         postsBody.textContent = dataPost.body;

//         let responseComments = await fetch(commentsUrl);

//         try {
//             if (responseComments.status != 200) {
//                 throw new Error('Error commentsUrl');
//             }

//             let data = await responseComments.json();

//             let currentComments = [];
//             Object.entries(data).forEach(c => {
//                 if (c[1].postId == dataPost.id) {
//                     currentComments.push(c);
//                 }
//             });

//             currentComments.forEach(c => {
//                 let lieEl = document.createElement('li');
//                 lieEl.id = c[0];
//                 lieEl.textContent = c[1].text;
//                 comments.appendChild(lieEl);
//             })

//         } catch (error) {
//             console.log(error);
//         }
//     }
// }

// attachEvents();