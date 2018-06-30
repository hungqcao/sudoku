import { Component, Directive, Input, Pipe, PipeTransform } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { Observable } from 'rxjs/Rx';
import { } from 'jasmine';
import { SudokuComponent } from './sudoku.component';
import { SudokuService } from '../services/sudoku.service';

describe('CampaignOverviewComponent', () => {
    let component: SudokuComponent;
    let mockSudokuService: SudokuService;
    let fixture: ComponentFixture<SudokuComponent>;

    mockSudokuService = jasmine.createSpyObj('mockSudokuService', ['getCurrentSudokuProblem']);

    beforeEach(() => {
        // Configure the testing module
        TestBed.configureTestingModule({
            declarations: [
                SudokuComponent
            ],
            providers: [
                { provide: SudokuService, useValue: mockSudokuService }
            ],
            imports: [
                FormsModule
            ]
        });
        // Create the component
        fixture = TestBed.createComponent(SudokuComponent);
        component = fixture.componentInstance;

        (<jasmine.Spy>mockSudokuService.getCurrentSudokuProblem).and.returnValue(Observable.of({}));

        // Call detect changes to fire the ngOnInit lifecycle method call
        fixture.detectChanges();
    });

    it('is initialized correctly', () => {
        expect(component).toBeDefined();
    });    
});