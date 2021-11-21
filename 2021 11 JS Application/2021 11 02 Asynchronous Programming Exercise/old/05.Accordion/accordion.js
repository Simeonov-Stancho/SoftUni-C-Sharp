let sectionElement = document.getElementById('section');

fetch(`http://localhost:3030/jsonstore/advanced/articles/list`)
.then(res=>res.json())
.then(data=>{
    let divElement = document.createElement('div');
    divElement.id = 'accordion';
    data.forEach(element => {
        let divElement = document.createElement('div');
        divElement.id = 'accordion';
        let title = element.title;
        let id = element._id;
        

        fetch('http://localhost:3030/jsonstore/advanced/articles/details/' + id)
        .then(res=>res.json())
        .then(subData =>{
            let content = subData.content;
            divElement.innerHTML = elementGenerator(title,content);
            sectionElement.appendChild(divElement);  
        })
        
    });
    
    
})

function elementGenerator(title,content){
    let newElement = `
    <div class="head">${title}<span class="button" onclick="toggle(event)">More</span>
        <div id="extra">
            <p>${content}</p>
        </div>
    </div>
    `;
    return newElement;
}


function toggle(e) {
        
        if(e.target.textContent == 'More'){
            e.target.nextElementSibling.style.display = 'block'
            e.target.textContent = 'Less';
        }else if(e.target.textContent == 'Less'){
            e.target.nextElementSibling.style.display = ''
            e.target.textContent = 'More';
        }
    


    
}


