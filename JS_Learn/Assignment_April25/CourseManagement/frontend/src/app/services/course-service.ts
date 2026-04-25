import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface Course {
  id: number;
  title: string;
  description: string;
  duration: number;
}

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private baseUrl = 'http://localhost:5288/api/courses';

  constructor(private http: HttpClient) { }

  getCourses() : Observable<Course[]> {
    return this.http.get<Course[]>(this.baseUrl);
  }
  getCourseById(id: number) : Observable<Course> {
    return this.http.get<Course>(`${this.baseUrl}/${id}`);
  }
  postCourse(course: Course) : Observable<Course> {
    return this.http.post<Course>(this.baseUrl, course);
  }
  putCourse(course: Course) : Observable<Course> {
    return this.http.put<Course>(`${this.baseUrl}/${course.id}`, course);
  }
  deleteCourse(id: number) : Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
