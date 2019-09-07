var ObjectState = {
    Unchanged: 0,
    Added: 1,
    Modified: 2,
    Deleted: 3
};


var createProjectItemMapping = {
    'CreateProjectItems': {
        key: function (createProjectItem) {
            return ko.utils.unwrapObservable(createProjectItem.ProjectItemId);
        },
        create: function (options) {
            return new CreateProjectItemViewModel(options.data);
        }
    }
};


CreateProjectItemViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, createProjectItemMapping, self);

    self.flagCreateProjectAsEdited = function () {
        if (self.ObjectState() != ObjectState.Added) {
            self.ObjectState(ObjectState.Modified);
        }
        return true;
    }
        
}


CreateProjectViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, createProjectItemMapping, self);

    self.save = function () {
        $.ajax({
            url: "/CreateProjects/Save/",   
            type: "POST",
            data: ko.toJSON(self),
            contentType: "application/json",
            success: function (data) {
                if (data.createProjectViewModel != null)
                    ko.mapping.fromJS(data.createProjectViewModel, {}, self);

                if (data.newLocation != null)
                    window.location = data.newLocation;
            }
        });
    },

        self.flagCreateProjectAsEdited = function () {
            if (self.ObjectState() != ObjectState.Added) {
                self.ObjectState(ObjectState.Modified);
            }
            return true;
        };

    self.addCreateProjectItem = function () {
        var createProjectItem = new CreateProjectItemViewModel({ ProjectItemId: 0, StartDate: "", EndDate: "", Credits: 0, ObjectState: ObjectState.Added });
        self.CreateProjectItems.push(createProjectItem);
    };

    self.deleteProjectItem = function (createProjectItem) {
        self.CreateProjectItems.remove(this);

        if (createProjectItem.ProjectItemId() > 0 && self.CreateProjectItemsToDelete.indexOf(createProjectItem.ProjectItemId()) == -1)
            self.CreateProjectItemsToDelete.push(createProjectItem.ProjectItemId());
    };
};

$("form").validate({
    submitHandler: function () {
        createProjectViewModel.save();
    },
    rules: {
        FirstName: {
            required: true
        },
        StartDate: {
            required: true,
        },
        EndDate: {
            required: true
        },
        Credits: {
            required: true,
            maxlenght: 2,
            range: [0,12]
        }
    },

    messages: {
        FirstName: {
            required: "you must type a user name :)!",
        }
    }
});

