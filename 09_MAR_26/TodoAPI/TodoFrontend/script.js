const API_URL = "http://localhost:5157/api/Todo";


async function loadTasks(){

const res = await fetch(API_URL);
const data = await res.json();

const list = document.getElementById("taskList");
list.innerHTML="";

data.forEach(todo => {

const li = document.createElement("li");

if(todo.isCompleted){
li.classList.add("completed");
}

let priorityClass="priority-medium";

if(todo.priority==="High") priorityClass="priority-high";
if(todo.priority==="Low") priorityClass="priority-low";

li.innerHTML = `
<div>
<input type="checkbox"
${todo.isCompleted ? "checked":""}
onchange="toggleComplete(${todo.id},'${todo.title}','${todo.priority}',this.checked)">

<span class="${priorityClass}">
${todo.title} (${todo.priority})
</span>
</div>

<div>
<button onclick="editTask(${todo.id},'${todo.title}','${todo.priority}',${todo.isCompleted})">Edit</button>
<button onclick="deleteTask(${todo.id})">Delete</button>
</div>
`;

list.appendChild(li);

});
}



async function addTask(){

const title=document.getElementById("taskInput").value;
const priority=document.getElementById("priorityInput").value;

if(title.trim()===""){
alert("Enter task first");
return;
}

const task={
title:title,
isCompleted:false,
priority:priority
};

await fetch(API_URL,{
method:"POST",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify(task)
});

document.getElementById("taskInput").value="";

loadTasks();

}



async function deleteTask(id){

await fetch(`${API_URL}/${id}`,{
method:"DELETE"
});

loadTasks();

}



async function toggleComplete(id,title,priority,status){

const updated={
id:id,
title:title,
priority:priority,
isCompleted:status
};

await fetch(`${API_URL}/${id}`,{
method:"PUT",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify(updated)
});

loadTasks();

}



async function editTask(id,oldTitle,priority,isCompleted){

const newTitle=prompt("Edit task:",oldTitle);

if(!newTitle) return;

const updated={
id:id,
title:newTitle,
priority:priority,
isCompleted:isCompleted
};

await fetch(`${API_URL}/${id}`,{
method:"PUT",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify(updated)
});

loadTasks();

}



async function searchTask(){

const keyword=document.getElementById("searchBox").value.toLowerCase();

const res=await fetch(API_URL);
const data=await res.json();

const filtered=data.filter(t =>
t.title.toLowerCase().includes(keyword)
);

const list=document.getElementById("taskList");
list.innerHTML="";

filtered.forEach(todo=>{
list.innerHTML+=`<li>${todo.title} (${todo.priority})</li>`;
});

}



function toggleDark(){
document.body.classList.toggle("dark");
}



loadTasks();