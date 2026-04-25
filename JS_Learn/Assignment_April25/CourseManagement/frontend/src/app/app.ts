import { Component, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CourseService } from './services/course-service';

interface Course {
  id: number;
  title: string;
  description: string;
  duration: number;
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  courses = signal<Course[]>([]);
  
  newCourse: Course = {
    id: 0,
    title: '',
    description: '',
    duration: 0
  };

  isSubmitting = signal(false);

  constructor(private courseService: CourseService) {}

  ngOnInit() {
    this.loadCourses();
  }

  loadCourses() {
    this.courseService.getCourses().subscribe({
      next: (data) => {
        if (data) {
          this.courses.set(data);
        }
      },
      error: (err) => console.error('Failed to load courses', err)
    });
  }

  onSubmit() {
    if (!this.newCourse.title || !this.newCourse.description || !this.newCourse.duration) return;
    
    console.log('Submitting course:', this.newCourse);
    this.isSubmitting.set(true);
    
    this.courseService.postCourse(this.newCourse).subscribe({
      next: (course) => {
        console.log('Course added successfully:', course);
        this.courses.update(courses => [...courses, course]);
        this.newCourse = { id: 0, title: '', description: '', duration: 0 };
        this.isSubmitting.set(false);
      },
      error: (err) => {
        console.error('Failed to add course:', err);
        alert(`Error: ${err.message || 'Failed to add course. Please check if the backend is running.'}`);
        this.isSubmitting.set(false);
      }
    });
  }

  deleteCourse(id: number) {
    if (confirm('Are you sure you want to delete this course?')) {
      this.courseService.deleteCourse(id).subscribe({
        next: () => {
          this.courses.update(courses => courses.filter(c => c.id !== id));
        },
        error: (err) => console.error('Failed to delete course', err)
      });
    }
  }
}
