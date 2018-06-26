/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShopParserClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}



//////1
<!DOCTYPE html>
<html>
<head>
    <meta charset = "utf-8" >
    < title > Работа с сервером в KnockoutJS</title>
       <script src = "https://code.jquery.com/jquery-2.2.3.min.js" ></ script >
   
       < script src= "https://ajax.aspnetcdn.com/ajax/knockout/knockout-3.4.0.js" ></ script >
   </ head >
   < body >
   


       < table class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Name</th>
            </tr>
        </thead>
        <tbody class="tableRows">           
        </tbody>
    </table>

    <form data-bind="submit: submitHandler, with: user">
        <input type = "text" name="login" data-bind="textInput: login" />
        <input type = "text" name="password" data-bind="textInput: password" />
        <button type = "submit" > Отправить </ button >
    </ form >
    < p data-bind="text: ko.toJSON(user)"></p>
    <script type = "text/javascript" >
        function AppViewModel()
{
    self = this;
    self.user = {
        login: ko.observable("login"),
                password: ko.observable("password")
            };

    self.submitHandler = function() {
                $.ajax({
            type: 'GET',
                    url: 'http://localhost:14216/api/ParserApi',
                    dataType: 'json'
                }).success(self.successHandler).error(self.errorHandler);
    };

    self.successHandler = function(data)
            {
        alert("Success!");
        if (data.length > 0)
        {
            var strResult = "";
            alert("Ok!");
                    $.each(data, function(index, product)
                    {
                strResult +=
                    "<tr>" +
                        "<td>" + product.Title + "</td>" +
                    "</tr>";
            });
            alert(strResult);

                    $(".tableRows").html(strResult);
        }
    };
    self.errorHandler = function()
            {
        alert("Error!");
    };
};
ko.applyBindings(new AppViewModel());
    </script>
</body>
</html>


    //////2
    <!DOCTYPE html>
<html>
<head>
    <meta charset = "utf-8" >
    < title > Работа с сервером в KnockoutJS</title>
       <script src = "https://code.jquery.com/jquery-2.2.3.min.js" ></ script >
   
       < script src= "https://ajax.aspnetcdn.com/ajax/knockout/knockout-3.4.0.js" ></ script >
   </ head >
   < body >
   







       < table class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Name</th>
            </tr>
        </thead>
        <tbody class="tableRows">           
        </tbody>
    </table>

    <form data-bind="submit: submitHandler, with: url">
        <input type = "text" name="shopUrl" data-bind="textInput: shopUrl" />
        <button type = "submit" > Отправить </ button >
    </ form >


    < p data-bind="text: ko.toJSON(url)"></p>
    
    <script type = "text/javascript" >
        function AppViewModel()
{
    self = this;
    self.url = {
        shopUrl: ko.observable("")
            };

    //GetAll
    //self.submitHandler = function ()
    //{
    //    var shopUrl = self.url.shopUrl;

    //    $.ajax({
    //        type: 'GET',
    //        url: 'http://localhost:14216/api/ParserApi',
    //        data: { url: shopUrl }                   
    //    });
    //};    



    //Parser
    self.submitHandler = function() {
                $.ajax({
            type: 'GET',
                    url: 'http://localhost:14216/api/ParserApi',
                    dataType: 'json'
                }).success(self.successHandler).error(self.errorHandler);
    };

    self.successHandler = function(data) {
        alert("Success!");
        if (data.length > 0)
        {
            var strResult = "";
            alert("Ok!");
                    $.each(data, function(index, product) {
                strResult +=
                    "<tr>" +
                   "<td><a data-item='" + product.Article + "' onclick='GetInfo(this);' >" + product.Title + "</a></td>" +
                   "<td>" + product.CurrentPrice + "</td>" +
                    "</tr>";
            });
            alert(strResult);

                    $(".tableRows").html(strResult);
        }
    };
    self.errorHandler = function() {
        alert("Error!");
    };


};
ko.applyBindings(new AppViewModel());
    </script>
</body>
</html>

















    ///////3
    <!DOCTYPE html>
<html>
<head>
    <meta charset = "utf-8" >
    < title > Работа с сервером в KnockoutJS</title>
       <script src = "https://code.jquery.com/jquery-2.2.3.min.js" ></ script >
   
       < script src= "https://ajax.aspnetcdn.com/ajax/knockout/knockout-3.4.0.js" ></ script >
   </ head >
   < body >
   


       < table data-bind= "foreach: records" >
   
           < tr >
   
               < td data-bind= "text: name" ></ td >
   
               < td data-bind= "text: description" ></ td >
   
           </ tr >
   
       </ table >
   

       < button data-bind= 'click: addGift' > Add Gift</button>
   

    <script type = "text/javascript" >


           function dealModel() {
    var self = this;
    self.records = ko.observableArray([]);

            $.getJSON("/api/deals/index", function(data) {
        self.records(data);
    })
        }
ko.applyBindings(new dealModel());



        var GiftModel = function(gifts)
        {
            var self = this;
self.gifts = ko.observableArray(gifts);

            self.addGift = function()
{
    alert("self.addGift!");
                $.ajax({
        type: 'GET',
                    url: 'http://localhost:14216/api/ParserApi',
                    dataType: 'json'
                }).success(self.successHandler).error(self.errorHandler);
};


self.successHandler = function(data)
{
    if (data.length > 0)
    {
                    $.each(data, function(index, product)
                    {
            self.gifts.push({
                name: product.Title,
                            price: product.CurrentPrice
                        });
        });
    }
};
self.errorHandler = function()
{
    alert("Error!");
};

        };

        var viewModel = new GiftModel([
            { name: "Tall Hat", price: "39.95" },
            { name: "Long Cloak", price: "120.00" }
        ]);
        ko.applyBindings(viewModel);








                





    </script>
</body>
</html>




    //////4
    <!DOCTYPE html>
<html>
<head>
    <meta charset = "utf-8" >
    < title > Работа с сервером в KnockoutJS</title>
       <link rel = "stylesheet" href= "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" >
   
       < link rel= "stylesheet" href= "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap-theme.min.css" >
   

       < script src= "https://code.jquery.com/jquery-2.2.3.min.js" ></ script >
   
       < script src= "https://ajax.aspnetcdn.com/ajax/knockout/knockout-3.4.0.js" ></ script >
   
       < script src= "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js" ></ script >
   

   </ head >
   < body >
   

       < div id= "todoList" class="conteiner wrapper">
        <div class="form-inline new-task">
            <div class="form-group">
                <input class="form-control" type="text" data-bind="textInput: newTaskTitle">
            </div>

            <div class="form-group">
                <button class="btn" data-bind="click: addTask">add</button>
            </div>
        </div>

        <div class="row">
            <div class="new-task col-lg-6">
                <h3>Task</h3>
                <div data-bind="visible: tasks().length">
                    <ul data-bind="foreach: tasks">
                        <li class="new-task checkbox">
                            <label data-bind="click:  $parent.checkTask">
                                <input type = "checkbox" >
                                < span data-bind="text: title"></span>
                                <a class="remove-task" href="#" data-bind="click: $parent.removeTask">
                                    (remove)
                                </a>
                            </label>
                        </li>
                    </ul>
                </div>
                <div data-bind="visible: !tasks().length">
                    no tasks
                </div>
            </div>

            <div class="new-task col-lg-6">
                <h3>Complete</h3>
                <div data-bind="visible: completeTasks().length">
                    <ul data-bind="foreach: completeTasks">
                        <li class="task">
                            <span data-bind="text: title"></span>
                            <a class="undo-task" href="#" data-bind="click: $parent.undoTask">
                                (undo)
                            </a>
                        </li>
                    </ul>
                </div>
                <div data-bind="visible: !completeTasks().length">
                    no tasks
                </div>
            </div>
        </div>
    </div>

    <script>
        (function (ko)
        {
    var ChecklistViewModel = function(checklist)
            {
        var self = this;

        this.checklist = checklist;//link on main model
        this.newTaskTitle = ko.observable('');
        this.tasks = ko.observableArray();
        this.completeTasks = ko.observableArray();

        this.addTask = function()
                {
            this.checklist.addTask(this.newTaskTitle());
            this.newTaskTitle('');
            this.tasks(this.checklist.tasks);
        };

        this.removeTask = function(taskObject, event)
                {
            self.checklist.removeTask(taskObject.id);
            self.tasks(self.checklist.tasks);
        };

        this.checkTask = function(taskObject, event)
                {
            self.checklist.checkTask(taskObject.id);
            self.tasks(self.checklist.tasks);
            self.completeTasks(self.checklist.completeTasks);
        };

        this.undoTask = function(taskObject, event)
                {
            self.checklist.undoTask(taskObject.id);
            self.tasks(self.checklist.tasks);
            self.completeTasks(self.checklist.completeTasks);
        };
    };

    //main model
    var Checklist = function()
            {
        this.tasks = [];
        this.completeTasks = [];

        this.addTask = function(taskTitle)
                {
            //console.log(taskTitle);
            this.tasks.push({
                id: this.tasks.length,
                        title: taskTitle
                    });
            console.log(this.tasks);
        };

        this.removeTask = function(id)
                {
            var tastIndex = this.getIndexById(id, this.tasks);

            if (typeof tastIndex !== 'undefined')
            {
                this.tasks.splice(tastIndex, 1);
            }
        };

        this.checkTask = function(id)
                {
            var tastIndex = this.getIndexById(id, this.tasks),
                task;

            if (typeof tastIndex !== 'undefined')
            {
                task = this.tasks[tastIndex];
                this.tasks.splice(tastIndex, 1);
                this.completeTasks.push(task);
            }
        };

        this.undoTask = function(id)
                {
            var tastIndex = this.getIndexById(id, this.completeTasks),
                task;

            if (typeof tastIndex !== 'undefined')
            {
                task = this.completeTasks[tastIndex];
                this.completeTasks.splice(tastIndex, 1);
                this.tasks.push(task);
            }
        };

        this.getIndexById = function(id, tasks)
                {
            var index;

            for (var i = 0, max = tasks.length; i < max; i++)
            {
                if (tasks[i].id === id)
                {
                    index = i;
                    break;
                }
            }

            return index;
        };

    };

    var checklist = new Checklist();

    ko.applyBindings(new ChecklistViewModel(checklist), document.getElementById('todoList'));
})(ko);



    </script>
</body>
</html>























    public ICollection<PriceViewModel> ChangePrices { get; set; }

public int Id { get; set; }
public int Article { get; set; }
public string Title { get; set; }
public decimal CurrentPrice
{
    get
    {
        if (ChangePrices.Count > 0)
        {
            var lastVal = (from v in ChangePrices
                           let maxId = ChangePrices.Max(p => p.Id)
                           where v.Id == maxId
                           select v.ChangePrice).FirstOrDefault();

            return lastVal;
        }
        else
        {
            return 0;
        }
    }
}
public string Currency { get; set; }
public string Characteristic { get; set; }
public string Path { get; set; }
public byte[] Image { get; set; }
public string Base64String { get; set; }



*/