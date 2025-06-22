using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StudentController
{
    private Student _model;
    private StudentView _view;

    public StudentController(Student model, StudentView view)
    {
        _model = model;
        _view = view;
    }

    public void SetStudentName(string name)
    {
        _model.Name = name;
    }

    public string GetStudentName()
    {
        return _model.Name;
    }

    public void SetStudentId(string id)
    {
        _model.Id = id;
    }

    public string GetStudentId()
    {
        return _model.Id;
    }

    public void SetStudentGrade(string grade)
    {
        _model.Grade = grade;
    }

    public string GetStudentGrade()
    {
        return _model.Grade;
    }

    public void UpdateView()
    {
        _view.DisplayStudentDetails(_model.Name, _model.Id, _model.Grade);
    }
}

